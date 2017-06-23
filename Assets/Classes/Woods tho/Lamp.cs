using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light lampje;

    public List<bool> lamps;

    public float maxTime;
    public float timer;

	void Update ()
    {
        if(lampje.enabled == true)
        {
            Times();
        }

        if(timer >= maxTime)
        {
            lampje.enabled = false;
            timer = 0;
        }
	}

    void Times()
    {
        timer += Time.deltaTime;
    }
}
