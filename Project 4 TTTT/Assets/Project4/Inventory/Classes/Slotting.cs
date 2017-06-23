using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slotting : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0) //if childCount is less then 0 return the first child.
            {
                return transform.GetChild(0).gameObject;
            }
            return null; //if no item return null/ nothing.
        }
    }

    public void OnDrop(PointerEventData eventData) //OnDropHandler lets you use OnDrop.
    {
        if (!item) //if it doesnt have an item set the new transform for the item.
        {
            DragInv.draggingItem.transform.SetParent(transform);
        }
    }
}
