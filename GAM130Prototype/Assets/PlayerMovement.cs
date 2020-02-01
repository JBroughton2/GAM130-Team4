using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public float jumpHeight;
    public GameObject flashlight;
    public bool flashlightOn;

    private bool isGrounded;
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //creates a small sphere that outputs a check value depending on what is in sphere
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //resets the velocity value if the player is grounded and not falling anymore.
        if(isGrounded && velocity.y < 0)
        {
            //is negative two just in case it happens before player hits the floor
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //this is the vector that uses the values of x and z to register player input
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        //Jump mechanic using a formula for calulating the force needed to jump relative to the gravity in the game
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetKeyDown(KeyCode.F) && !flashlightOn)
        {
            flashlight.SetActive(true);
            flashlightOn = true;
        }else if (Input.GetKeyDown(KeyCode.F) && flashlightOn)
        {
            flashlight.SetActive(false);
            flashlightOn = false;
        }

        
        //this builds the velocity so the player can fall as if gravity is acting on it
        velocity.y += gravity * Time.deltaTime;
        //this is using that velocity value to actually move the player down
        controller.Move(velocity * Time.deltaTime);
    }
}
