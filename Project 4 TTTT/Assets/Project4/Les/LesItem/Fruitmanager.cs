using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitmanager : MonoBehaviour {

    public Apple apple;
    public Banana banana;

	void Start () {

        apple = new Apple();
        banana = new Banana();
        print(apple.geschilt);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
