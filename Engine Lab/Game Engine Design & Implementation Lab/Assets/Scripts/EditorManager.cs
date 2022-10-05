using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static SpikeEditorEvents;

public class EditorManager : MonoBehaviour
{
    PlayerAction inputAction;
    public static EditorManager instance;

    public Camera mainCam;
    public Camera editorCam;

    public GameObject prefab1;
    public GameObject prefab2;

   public GameObject item;

    public bool editorMode = false;
    public bool instantiated = false;

    Vector3 mousePos;
    Subject subject = new Subject();

    ICommand command;

    UIManager ui;

    // Enable and Disable player actions script
    private void OnEnable()
    {
        inputAction.Editor.Enable();
    }

    private void OnDisable()
    {
        inputAction.Editor.Disable();
    }

    // Start is called before the first frame update
    //changed awake to start
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        // now uses player input controller
        //inputAction = PlayerInputController.controller.inputAction;
        inputAction = PlayerController.instance.inputAction;

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

        inputAction.Editor.Additem1.performed += cntxt => AddItem(1);

        inputAction.Editor.Additem2.performed += cntxt => AddItem(2);

        inputAction.Editor.Dropitem.performed += cntxt => Dropitem();

        editorCam.enabled = false;
        mainCam.enabled = true;

        ui = GetComponent<UIManager>();
    }


    private void SwitchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;

        Debug.Log("Pressing E");
        ui.ToggleEditorUI();
    }

    private void AddItem(int itemId)
    {
        if(editorMode && !instantiated)
        {
            switch (itemId)
            {
                case 1:
                    {
                     item = Instantiate(prefab1);
                        SpikeBall spike1 = new SpikeBall(item, new GreenMat());
                        subject.AddObserver(spike1);
                    }
                    break;
                case 2:
                    {
                     item = Instantiate(prefab2);
                        SpikeBall spike2 = new SpikeBall(item, new GreenMat());
                        subject.AddObserver(spike2);
                    }
                    break;

                default:
                    break;
            }
            subject.Notify();
            instantiated = true;
        }
    }

    private void Dropitem()
    {
        if (editorMode && instantiated)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().enabled = true;

            command = new PlaceItemCommand(item.transform.position, item.transform);
            CommandInvoker.AddCommand(command);

            instantiated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam.enabled == false && editorCam.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3 (mousePos.x, mousePos.y, 10.0f);
            item.transform.position = editorCam.ScreenToWorldPoint(mousePos);
        }
    }
}
