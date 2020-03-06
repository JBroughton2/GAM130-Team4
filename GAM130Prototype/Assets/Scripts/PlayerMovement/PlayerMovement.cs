using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField]
    private CharacterController m_controller;
    private Camera mainCamera;
    private PlayerInputHandler m_InputHandler;
    public Animator viewModel;

    [Header("Movement")]
    public float m_speed;
    public float m_inAirSpeed;
    [SerializeField]
    private float sprintSpeedModifier;
    private bool isSprinting;
    private bool crouching;

    [Header("Jumping")]
    public float m_gravity;
    public float m_jumpHeight;
    public Transform m_groundCheck;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    Vector3 m_velocity;
    bool m_isGrounded;

    [Header("Crouching")]
    [SerializeField]
    private Transform crouchingPos;

    void Start()
    {
        mainCamera = this.GetComponentInChildren<Camera>();
        Interactable.setPlayerAnimator(viewModel);
        isSprinting = false;
        crouching = false;
    }

    void FixedUpdate()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);

        if(m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }


        if (m_isGrounded)
        {
            viewModel.SetBool("Grounded", true);
            viewModel.ResetTrigger("Jump");
            Movement();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                Sprinting();
            }
            else
            {
                isSprinting = false;
            }

            if (isSprinting)
            {
                viewModel.SetBool("Sprint", true);
            }
            else if (!isSprinting)
            {
                viewModel.SetBool("Sprint", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && !crouching)
            {
                crouching = true;
                Crouching();
            }


        }
        else if (!m_isGrounded)
        {
            viewModel.SetBool("Grounded", false);

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveAir = transform.right * x + transform.forward * z;

            m_controller.Move(moveAir * m_inAirSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            Jump();
        }

        m_velocity.y += m_gravity * Time.deltaTime;
        m_controller.Move(m_velocity * Time.deltaTime);
    }

    void Jump()
    {
        m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        
        m_controller.Move(move * m_inAirSpeed * Time.deltaTime);
    }

    void Sprinting()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        m_controller.Move(move * m_inAirSpeed * sprintSpeedModifier * Time.deltaTime);
    }

    void Crouching()
    {
        if (crouching)
        {
            mainCamera.transform.position = crouchingPos.position;
        }

    }



}
