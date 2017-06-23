using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public List<GameObject> slot = new List<GameObject>();
    public GameObject item;
    public Text pickUpText;
    DragInv draginv;
    Slotting slotting;
    public bool pickedUp;

    public GameObject panel, panel2;
    public bool inventoryOpen;

	void Start ()
    {
        item = GameObject.FindWithTag("Item");
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("I") && inventoryOpen == false)
        {
            panel.SetActive(true);
            panel2.SetActive(true);
            inventoryOpen = true;
        }
        if (Input.GetButtonDown("I") && inventoryOpen == true)
        {
            panel.SetActive(false);
            panel2.SetActive(false);
            inventoryOpen = false;
        }


        float distance = Vector3.Distance(item.transform.position, gameObject.transform.position);
        if(distance <= 4)
        {
            pickUpText.text = "Press E to pickup";
        }
        else
        {
            pickUpText.text = null;
        }
        if (Input.GetButtonDown("E"))
        {
            for (int i = 0; i <= slot.Count; i++)
            {
                if (slot[i].GetComponent<Slotting>().fits == true)
                {
                    pickedUp = true;
                    pickUpText.text = null;
                    Destroy(item.gameObject);
                }
            }
        }
	}
}