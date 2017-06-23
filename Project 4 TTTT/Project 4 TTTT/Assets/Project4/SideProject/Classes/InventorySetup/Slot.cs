using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public GameObject stuff;

    public Item spul;

    public string bitch;

    public void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Item")
        {
            bitch = c.collider.gameObject.GetComponent<Item>().naam;
            spul = c.collider.gameObject.GetComponent<Item>();
            stuff = c.collider.gameObject;
            //c.collider.gameObject.GetComponent<Renderer>(); rend.enabled = true;
            Inventory.pickUp = true; 
        }
    }
}
