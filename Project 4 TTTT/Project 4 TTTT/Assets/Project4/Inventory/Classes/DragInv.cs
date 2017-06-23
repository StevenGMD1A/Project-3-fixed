using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragInv : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject draggingItem;

    Transform startParent;

    Vector3 startPosition;

    bool start = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingItem = gameObject;
        startPosition = transform.position; //The transform of an object.
        startParent = transform.parent; //Used to set the new transform to one of the set slots.

        GetComponent<CanvasGroup>().blocksRaycasts = false; //Making sure it doesnt block raycasts.
        draggingItem.GetComponent<LayoutElement>().ignoreLayout = true; //Making sure it doesnt mess with the layout.
        draggingItem.transform.SetParent(draggingItem.transform.parent.parent);
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; //Moving the object with the mouse.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingItem = null;

        if (transform.parent == startParent)
        {
            transform.position = startPosition; //Setting the new position to the location of an empty slot.
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true; //Once finished dragging needs to be false.

        draggingItem.GetComponent<LayoutElement>().ignoreLayout = false; //Making sure it doesnt mess up the layout.
    }
}