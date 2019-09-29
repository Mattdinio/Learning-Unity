using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float positiveForce = 50f;
    public bool moveLeft = false;
    public bool moveRight = false;
    public bool moveForward = false;
    public bool moveBack = false;
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //left right movement
        if (Input.GetAxis("Horizontal") > 0 ){
            moveRight = true;
        } else if (Input.GetAxis("Horizontal") < 0) {
            moveLeft = true;
        } else {
            moveLeft = false;
            moveRight = false;
        }

        //forward back movement
        if (Input.GetAxis("Vertical") > 0){
            moveForward = true;
        } else if (Input.GetAxis("Vertical") < 0) {
            moveBack = true;
        } else {
            moveForward = false;
            moveBack = false;
        }
        //jump movement
        if (Input.GetKey("space") || Input.GetKey("joystick button 0")) {
            jump = true;
        } else {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveRight == true)
        {
            rb.AddForce(positiveForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (moveLeft == true)
        {
            rb.AddForce(-positiveForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (moveForward == true)
        {
            rb.AddForce(0, 0, positiveForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (moveBack == true)
        {
            rb.AddForce(0,0, -positiveForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (jump)
        {
            rb.AddForce(0, (positiveForce + 100) * Time.deltaTime, 0);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<gameManager>().endgame();
        }
    }
}
