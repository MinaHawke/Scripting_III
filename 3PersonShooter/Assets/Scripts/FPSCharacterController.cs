using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public int m_walkSpeed;
    CharacterController m_controller;
    Vector3 m_playerCameraRotation;
    public float m_playerCameraRotationXLimit;
    public float m_playerCameraRotationSpeed;
    Camera m_playerCamera;

    //public float m_health;
    //public float stamina;

    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move *= m_walkSpeed;
        m_controller.Move(move * Time.deltaTime);

        m_playerCameraRotation.y += Input.GetAxis("Mouse X") * m_playerCameraRotationSpeed;
        m_playerCameraRotation.x += -Input.GetAxis("Mouse Y") * m_playerCameraRotationSpeed;
        m_playerCameraRotation.x = Mathf.Clamp(m_playerCameraRotation.x, -m_playerCameraRotationXLimit,
        m_playerCameraRotationXLimit);
        m_playerCamera.transform.localRotation = Quaternion.Euler(m_playerCameraRotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, m_playerCameraRotation.y);
    }
}
