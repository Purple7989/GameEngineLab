using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//defines the place item and remove item functions used by our execute and undo functions
public class ItemPlacer : MonoBehaviour
{
    // list of item transforms
    static List<Transform> items;

    public static void PlaceItem(Transform item)
    {
        Transform newItem = item;
        if (item == null)
        {
            items = new List<Transform>();
        }
        items.Add(newItem);
    }

    public static void RemoveItem(Vector3 position)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].position == position)
            {
                GameObject.Destroy(items[i].gameObject);
                items.RemoveAt(i);
                break;
            }
        }
    }

    //public static void RedoItem()
    //{

    //}
}
