using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 movement;
    Rigidbody rb;
    public float speed;
    public float gravityForce;
    public bool under;
    public GameObject splashFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!CanvasManager.instance.gameOver)
        {
            rb.AddForce(movement, ForceMode.Impulse);

            if (transform.position.y <= 0)
            {
                if(!under)
                { under = true;
                    GetComponentInChildren<ParticleSystem>().Play();
                    Splash();
                }
                movement = new Vector3(Input.GetAxis("Horizontal") * speed, (Input.GetAxis("Vertical") * speed) + gravityForce, 0);
            }
            else if (transform.position.y >= 1)
            {
                if (under)
                { under = false;
                    GetComponentInChildren<ParticleSystem>().Stop();
                    Splash();
                }
                movement = new Vector3(Input.GetAxis("Horizontal") * speed, (Input.GetAxis("Vertical") * speed) - gravityForce, 0);
            }
            if (transform.position.y >= 0)
            {
                movement = new Vector3(0, -gravityForce, 0);
            }
            if (transform.position.y <= -10)
            {
                movement = new Vector3(0, gravityForce, 0);
            }
        }
    }
    void Splash()
    {
        GameObject fx = GameObject.Instantiate(splashFX);
        fx.transform.position = transform.position;
    }
}
