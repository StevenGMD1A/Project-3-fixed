using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontrol : MonoBehaviour
{
    public Rigidbody player;
    public Vector3 jump;

    public float speed = 10.0f;

    public int strength = 20;

    public bool mayjump = true;
    public bool lockState;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lockState = false;
    }

    void FixedUpdate()
    {
        float updown = Input.GetAxis("Vertical") * speed;
        float leftright = Input.GetAxis("Horizontal") * speed;
        updown *= Time.deltaTime;
        leftright *= Time.deltaTime;

        transform.Translate(leftright, 0, updown);

        if (Input.GetButtonDown("Jump") && mayjump == true)
        {
            player.AddForce(jump * strength);
            mayjump = false;
        }

        if (Input.GetButtonDown("Cancel") && lockState == false)
        {
            Cursor.lockState = CursorLockMode.None;
            lockState = true;
        }

        if (Input.GetButtonDown("Cancel") && lockState == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            lockState = false;
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == ("ground"))
        {
            mayjump = true;
        }
    }
}