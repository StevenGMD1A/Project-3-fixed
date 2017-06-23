using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCam : MonoBehaviour
{
    private const float C_DIS_MIN = 10f;
    private const float C_DIS_MAX = 25f;

    private const float Y_ANGLE_MIN = 10f;
    private const float Y_ANGLE_MAX = 50f;

    private Transform camTrans;
    public Transform lookAt;

    private Camera mainCam;

    public float sensScroll = 7;
    public float distance = 10.0f;

    private float currentY = 1f;
    public float currentX = 1f;
    public float sensX = 3f;
    public float sensY = 2f;

    private void Start()
    {
        camTrans = transform;

        mainCam = Camera.main;
    }

    private void Update()
    {
        distance += Input.GetAxis("Mouse ScrollWheel") * sensScroll;
        currentX += Input.GetAxis("Mouse X") * sensX;
        currentY += Input.GetAxis("Mouse Y") * sensY;

        distance = Mathf.Clamp(distance, C_DIS_MIN, C_DIS_MAX);
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTrans.position = lookAt.position + rotation * dir;
        camTrans.LookAt(lookAt.position);
    }
}
