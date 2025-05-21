using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 m_offset;
    [SerializeField] private Transform m_playerTransform;

    private void Start()
    {
        m_offset = transform.position - m_playerTransform.position;
    }

    private void Update()
    {
       HoldCamera();
       transform.position = m_playerTransform.position + m_offset;
    }
    private void HoldCamera()
    {
        transform.LookAt(m_playerTransform, Vector3.up);
    }
}
