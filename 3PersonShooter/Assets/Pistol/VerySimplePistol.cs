using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimplePistol : MonoBehaviour
{
    public Transform m_raycastSpot;
    public float m_damage = 80.0f;
    public float m_forceToApply = 20.0f;
    public float m_weaponRange = 9999.0f;
    public Texture2D m_crosshairTexture;
    public AudioClip m_fireSound;
    private bool m_canShot;
    public int m_municionActual;
    public int m_municionMax = 12;
    private float m_TiempoEntreDisparos;
    private float m_TiempoDesdeUltimoDisparo;
    public int m_frecuenciaDeDisparos = 4;
    private int m_accuracyDropPerShot;
    private float m_currentAccuracy;
    private float m_accuracy;
    private float m_accuracyRecoverPerSecond;

    private void Start()
    {
        m_municionActual = m_municionMax;
        m_TiempoEntreDisparos = 1 / m_frecuenciaDeDisparos;
    }

    private void Update()
    {
        m_currentAccuracy = Mathf.Lerp(m_currentAccuracy, m_accuracy, m_accuracyRecoverPerSecond * Time.deltaTime);

        if (m_canShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                if (m_municionActual >= 1)
                {
                    print(m_municionActual);
                    Shot();
                    m_municionActual--;

                }
                else
                {
                    m_municionActual = m_municionMax;
                }
            }
        }
        else
        {
            m_TiempoDesdeUltimoDisparo += Time.deltaTime;
            if (m_TiempoDesdeUltimoDisparo >= m_TiempoEntreDisparos)
            {
                m_canShot = true;
            }
        }
    }

    private void OnGUI()
    {
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        Rect auxRect = new Rect(center.x - 20, center.y - 20, 20, 20);
        GUI.DrawTexture(auxRect, m_crosshairTexture, ScaleMode.StretchToFill);
    }


    private void Shot()
    {
        m_TiempoDesdeUltimoDisparo = 0;
        m_canShot = false;

        float accuracyModifier = (100 - m_currentAccuracy) / 1000;
        Vector3 directionForward = m_raycastSpot.forward;
        directionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        m_currentAccuracy -= m_accuracyDropPerShot;
        m_currentAccuracy = Mathf.Clamp(m_currentAccuracy, 0, 100);

        Ray ray = new Ray(m_raycastSpot.position, directionForward);


        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_weaponRange))
        {
            Debug.Log("Hit " + hit.transform.name);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(ray.direction * m_forceToApply);
                Debug.Log("Hit");
            }
        }
        Debug.DrawRay(m_raycastSpot.position, ray.direction, Color.red, 4);

        GetComponent<AudioSource>().PlayOneShot(m_fireSound);
    }
}
