using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementP : MonoBehaviour
{
    public PersonCam camtransform;

    public Rigidbody player;

    public float camX;

    public RaycastHit rayhit;

    public Vector3 movement;
    public Vector3 jumpHeight = new Vector3 (0, 400, 0);

    public int upDrain = 1;
    public int downDrain = 2;
    public int durationEx = 3;

    public float maxStamina = 10;
    public float minStamina = 1.2f;
    public float stamina = 8;
    public float oriSpeed = 4;
    public float runSpeed = 1.3f;
    public float speed = 4;
    public float groundSpeed = 4;
    public float airSpeed = 3;
    //public float jumpHeight;
    public float fallSpeed = 1.1f;

    public float ray = 1.2f;

    public bool grounded;
    public bool sprinting;
    public bool exhausted;

	void FixedUpdate ()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        camX = camtransform.currentX;

        player.rotation = Quaternion.Euler (0, camX, 0);
        movement = new Vector3 (horizontal, 0, forward) * speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            player.AddForce(jumpHeight);

            if (!sprinting)
            {
                speed = airSpeed;
            }
            else
            {
                speed = oriSpeed;
            }
        }

        if (Input.GetButton("LeftShift") && exhausted == false && grounded)
        {
            sprinting = true;
            stamina -= Time.deltaTime * downDrain;
            speed = groundSpeed * runSpeed;
            Debug.Log("ja");
        }
        else
        {
            sprinting = false;
            speed = oriSpeed;

                if(stamina <= maxStamina)
                {
                    stamina += Time.deltaTime * upDrain;
                }

        }

        if (stamina <= minStamina)
        {
            exhausted = true;
            StartCoroutine(ExhaustedTime(durationEx));
        }

        if (!grounded)
        {
            if (player.velocity.y < -0.1)
            {
                player.velocity = new Vector3(0, player.velocity.y * fallSpeed, 0);
            }
        }

        Move();

        Debug.DrawRay(transform.position, -transform.up * ray, Color.red);
    }

    void Move()
    {
        transform.Translate(movement * Time.deltaTime * speed);
    }

    void Raycast()
    {
        if (Physics.Raycast(transform.position, -transform.up, out rayhit, ray))
        {

            if (rayhit.collider.gameObject.tag == "Ground")
            {
                Debug.Log("fuck");
                grounded = true;
                speed = groundSpeed;
            }
        }
    }

    IEnumerator ExhaustedTime(float time)
    {
        yield return new WaitForSeconds(time);
        exhausted = false;
    }

    void OnCollisionEnter(Collision c)
    {
        Raycast();
    }
}
