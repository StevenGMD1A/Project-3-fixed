using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notez : MonoBehaviour
{
    public List<bool> musicnotes = new List<bool>();
    public List<AudioSource> musicclips = new List<AudioSource>();
    public List<Light> lamps = new List<Light>();

    public AudioSource zelda;

    public Transform linestart, lineend;

    private float timer;

    public int intz;

    public bool geluid = false;

    void Start()
    {   
        zelda.Pause();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Linecasting();
        if (Input.GetButtonDown("Fire1"))
        {
            Loopy();
            Lights();
        }
        if (geluid == true)
        {
            zelda.UnPause();
        }
        else zelda.Pause();
    }
    void Linecasting()
    {
        Debug.DrawLine(linestart.position, lineend.position, Color.red);

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("F")))
        {
            musicnotes[0] = true;
            Debug.Log("I touched a F box");
        }
        else
        {
            musicnotes[0] = false;
        }
        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("A")))
        {
            musicnotes[1] = true;
        }
        else
        {
            musicnotes[1] = false;
        }

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("B")))
        {
            musicnotes[2] = true;
        }
        else musicnotes[2] = false;

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("E")))
        {
            musicnotes[3] = true;
        }
        else musicnotes[3] = false;

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("D")))
        {
            musicnotes[4] = true;
        }
        else musicnotes[4] = false;

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("C")))
        {
            musicnotes[5] = true;
        }
        else musicnotes[5] = false;

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("G")))
        {
            musicnotes[6] = true;
        }
        else musicnotes[6] = false;

        if (Physics.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("Zelda"))&& Input.GetButtonDown("Fire1"))
        {
            if (geluid == false)
            {
                geluid = true;
            }
            else geluid = false;
        }
    }
	void Loopy ()
    {
        for (int i = 0; i < musicnotes.Count; i++)
        {
            if (musicclips[i] != null && musicnotes[i] == true)
            {
                musicclips[i].Play();
                Debug.Log("playedness");
            }
        }
    }
    void Lights()
    {
        for (int i = 0; i < lamps.Count; i++)
        {
            if (musicnotes[i] == true)
            {
                lamps[i].enabled = true;
                Debug.Log("on");
                intz = i;
                timer = 1;
            }
            else
            {
                lamps[i].enabled = false;
            }
        }
    }
}
