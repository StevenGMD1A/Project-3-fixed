using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    public float floatX;
    public float speed;
    public float bulletSpeed;
    public GameObject bullet;

    void Update()
    {
        floatX = floatX + speed * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, floatX, 0);

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
