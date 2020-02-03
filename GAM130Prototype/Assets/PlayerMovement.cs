﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Base Movement")]
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private float gravity = -9.81f;
    private CharacterController controller;
    private float x;
    private float z;
    private Vector3 velocity;

    [Header("Jumping & Ground Checking")]
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float jumpHeight;
    private float groundDistance;
    private LayerMask groundMask;
    private bool isGrounded;
    
    [Header("Flashlight ")]
    [Space]
    [SerializeField]
    private GameObject flashlight;
    private bool flashlightOn;

    [Header("Sprinting")]
    private float sprintMultiplier;

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

        PlayerMove();
        PlayerJump();
        Flashlight();
        
        //this builds the velocity so the player can fall as if gravity is acting on it
        velocity.y += gravity * Time.deltaTime;
        //this is using that velocity value to actually move the player down
        controller.Move(velocity * Time.deltaTime);
    }

    void PlayerMove()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //this is the vector that uses the values of x and z to register player input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 sprint = transform.right * x + transform.forward * z;
            controller.Move(sprint * speed * sprintMultiplier * Time.deltaTime);
        }
    }
    void PlayerJump()
    {
        //Jump mechanic using a formula for calulating the force needed to jump relative to the gravity in the game
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    void Flashlight()
    {

        if (Input.GetKeyDown(KeyCode.F) && !flashlightOn)
        {
            flashlight.SetActive(true);
            flashlightOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && flashlightOn)
        {
            flashlight.SetActive(false);
            flashlightOn = false;
        }
    }
}
