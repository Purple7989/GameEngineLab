using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    PlayerAction inputAction;
    //commands needed to be executed
    static Queue<ICommand> commandBuffer;
    //command actions we performed
    static List<ICommand> commandHistory;

    static int counter;


    // Start is called before the first frame update
    void Start()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();

        //inputAction = PlayerController.instance.inputAction;
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Undo.performed += cntxt => UndoCommand();
    }
    public static void AddCommand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }

    public void UndoCommand()
    {
        if(commandBuffer.Count <= 0)
        {
            if (counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
    }
}
