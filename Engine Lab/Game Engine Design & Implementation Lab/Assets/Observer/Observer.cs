using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract observer class that concrete observers inheret 
public abstract class Observer
{
    // concrete observers must override OnNotify
    public abstract void OnNotify();
}
// example of concrete observer class that inherets from observer abstract class
public class SpikeBall : Observer
{
    GameObject spikeObj;

    SpikeEditorEvents spikeEvent;

    public SpikeBall(GameObject spikeObj, SpikeEditorEvents spikeEvent)
    {
        this.spikeObj = spikeObj;
        this.spikeEvent = spikeEvent;
    }
    // The OnNotify function is overrided and told to change the color when it is called
    public override void OnNotify()
    {
        SpikeColor(spikeEvent.SpikeEditorColor());
    }
    // called by OnNotify function
    void SpikeColor(Color mat)
    {
        if(spikeObj)
        {
            spikeObj.GetComponent<Renderer>().materials[0].color = mat;
        }
    }
}