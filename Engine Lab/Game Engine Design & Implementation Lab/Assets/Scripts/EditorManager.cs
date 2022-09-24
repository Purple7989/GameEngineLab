using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCam;

    public GameObject prefab1;
    public GameObject prefab2;

    GameObject item;

    public bool editorMode = false;
    bool instantiated = false;


    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new PlayerAction();

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

        inputAction.Editor.Additem1.performed += cntxt => AddItem(1);

        inputAction.Editor.Additem2.performed += cntxt => AddItem(2);

        inputAction.Editor.Dropitem.performed += cntxt => Dropitem();

        editorCam.enabled = false;
        mainCam.enabled = true;
    }

    private void SwitchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;
        Debug.Log("Pressing E");
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
                    }
                    break;
                case 2:
                    {
                     item = Instantiate(prefab2);
                    }
                    break;

                default:
                    break;
            }

            instantiated = true;
        }
    }

    private void Dropitem()
    {
        
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
    }
}
