using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Range(0, 10)] private float m_speed;
    [SerializeField, Range(0, 2)] private float m_jumpHeight;

    private CharacterController m_controller;
    private Vector3 m_plVelocity;
    public bool m_isOnGround { get; private set; }
    private float m_gravity = -9.81f;

    [SerializeField] private GameObject m_plArmature;
    private Animator m_animator;
    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        m_animator = m_plArmature.GetComponent<Animator>();
    }

    private void Update()
    {
        m_isOnGround = m_controller.isGrounded;
        if(m_isOnGround && m_plVelocity.y < 0)
        {
            m_plVelocity.y = 0.0f;
            m_animator.SetBool("Grounded", true);
            m_animator.SetBool("Jump", false);
        }

        // horizontal
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1f);
        if(movement == Vector3.zero)
        {
            m_animator.SetFloat("Speed", 0);
        }

        if (movement != Vector3.zero)
        {
            m_animator.SetFloat("Speed", m_speed);
            transform.forward = movement;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && m_isOnGround)
        {
            m_plVelocity.y = Mathf.Sqrt(m_jumpHeight * -1.0f* m_gravity);
            m_animator.SetBool("Jump", true);
        }

        m_plVelocity.y += m_gravity * Time.deltaTime;

        Vector3 finalMove = (movement * m_speed) + m_plVelocity.y * Vector3.up;
        m_controller.Move(finalMove);
        
    }
    
}
