using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Servers as our inferace command class
// defines execute and undo functions that other functions override
public interface ICommand
{
       public void Execute();
       public void Undo();
        //void Redo();
}
