using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherets ICommand class and defines execute & Undo
public class PlaceItemCommand : ICommand
{
    // subclass of interface
    Vector3 position;
    Transform item;
    
    //constructor that intiliazed our variables we made
    public PlaceItemCommand(Vector3 position, Transform item)
    {
        this.position = position;
        this.item = item;
    }
    //Execute Command defines what happens when the execute command is called.
   public void Execute()
    {
        ItemPlacer.PlaceItem(item);
    }
   public void Undo()
    {
        ItemPlacer.RemoveItem(position);
    }
}
