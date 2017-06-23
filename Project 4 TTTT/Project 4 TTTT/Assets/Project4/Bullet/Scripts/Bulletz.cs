using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletz : MonoBehaviour
{
    public Vector3 shoot = new Vector3(0,2,10);
    public float speed = 2;
    public int durationB = 3;

    void Start()
    {
        StartCoroutine(Alive(durationB));
    }

    void Update()
    {
        transform.Translate(shoot * speed * Time.deltaTime);
    }

    IEnumerator Alive(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
