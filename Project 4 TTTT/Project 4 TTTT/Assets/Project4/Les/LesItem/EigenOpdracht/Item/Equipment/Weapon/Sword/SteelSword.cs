using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelSword : Weapon{

    public int dmg = 5;

    public void SetStats()    {
        onehanded = true;
        durabillity = 100;  
    }

}
