using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController m_controller;
    PlayerInputHandler m_InputHandler;
    public Animator viewModel;
    public float m_speed = 12f;
    public float m_gravity;
    public float m_jumpHeight;
    public Transform m_groundCheck;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    Vector3 m_velocity;
    bool m_isGrounded;

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);

        if(m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        m_controller.Move(move * m_speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
        }

        m_velocity.y += m_gravity * Time.deltaTime;
        m_controller.Move(m_velocity * Time.deltaTime);
    }
}
