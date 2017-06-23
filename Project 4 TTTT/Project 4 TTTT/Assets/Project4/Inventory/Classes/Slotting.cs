using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slotting : MonoBehaviour, IDropHandler
{
    private GameObject player;
    public GameObject itempickup;
    public bool fits;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Pickup>().slot.Add(gameObject);
    }
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
    void Update()
    {
        if(player.GetComponent<Pickup>().pickedUp == true)
        {
            itempickup = player.GetComponent<Pickup>().gameObject;
        }
    }
    public void OnDrop(PointerEventData eventData) //OnDropHandler lets you use OnDrop.
    {
        if (!item) //if it doesnt have an item set the new transform for the item.
        {
            fits = true;
            if (itempickup != null)
            {
                DragInv.draggingItem.transform.SetParent(transform);
            }
            else
            {
                player.GetComponent<Pickup>().transform.SetParent(transform);
                player.GetComponent<Pickup>().pickedUp = false;
            }
        }
        else { fits = false; }
    }
}
