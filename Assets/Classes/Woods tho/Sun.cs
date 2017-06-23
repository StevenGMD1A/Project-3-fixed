using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Light sun;

    public RaycastHit rayhit;

    public Vector3 rotationSun;
    public Vector3 beginRotationSun;

    public float rayi;

    public bool night;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out rayhit, rayi) && rayhit.collider.gameObject.tag == "Sun")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!night)
                {
                    Debug.Log("yes");
                    sun.transform.eulerAngles = (rotationSun);
                    night = true;
                }
                else if (night)
                {
                    sun.transform.eulerAngles = (beginRotationSun);
                    night = false;
                }
            }
        }
    }
}
