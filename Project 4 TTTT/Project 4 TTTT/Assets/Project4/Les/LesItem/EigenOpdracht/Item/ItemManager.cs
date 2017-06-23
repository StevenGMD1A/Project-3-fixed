using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public SteelSword steelsword;

	// Use this for initialization
	void Start () {

        steelsword.SetStats();
        steelsword = new SteelSword();
        print(steelsword.dmg);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
