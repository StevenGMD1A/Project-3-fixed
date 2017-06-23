using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public List<Lamp> lampen = new List<Lamp>();

    public Vector3 startPos;

    public GameObject player;

    public int maxLives;
    public int lives;

    public bool ded;

    public void Reset()
    {
        player.transform.position = startPos;
        lives = maxLives;

        for(int i = 0; i < lampen.Count; i++)
        {
            lampen[i].timer = lampen[i].maxTime + 1;
        }
    }
}
