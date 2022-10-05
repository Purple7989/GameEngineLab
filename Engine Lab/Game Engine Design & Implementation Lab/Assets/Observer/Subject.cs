using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// subject class holds list of observers allows others to add them to the list & notifies each observer
public class Subject
{
    //list of obserers
    List<Observer> observers = new List<Observer>();

   // loop through list of observers and notify each of them
    public void Notify()
    {
        for(int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify();
        }
    }
    //allows for files to add them selves as an observer and adds them to the list
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }
}
