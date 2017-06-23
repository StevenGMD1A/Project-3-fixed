using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 move;

    public float speed;

	void Start () {
		
	}
	
	void Update () {

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;

        transform.Translate(move);
	}
}
