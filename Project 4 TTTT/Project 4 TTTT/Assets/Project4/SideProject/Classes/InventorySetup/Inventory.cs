using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static bool pickUp;

    public Slot slotje;

    public string ja;

    public List<Slot> inv = new List<Slot>();

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ja = inv[1].bitch;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ja = inv[2].bitch;
        }

        if (pickUp)
        {
            PickingUp();
            inv.Add(slotje);
            print(slotje.bitch);
            pickUp = false;
        }
    }

    public void PickingUp()
    {
        for (int i = 0; i < 1; i++)
        {
            if (pickUp)
            {
                slotje = GetComponent<Slot>();
            }
        }
    }
}
