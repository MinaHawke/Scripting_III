using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimplePistol : MonoBehaviour
{
    public WeaponInfo Weapon;
    public Transform m_raycastSpot;
    public Texture2D m_crosshairTexture;
    private bool m_canShot;
    public int m_municionActual;
    private float m_TiempoEntreDisparos;
    private float m_TiempoDesdeUltimoDisparo;
    public int m_accuracyDropPerShot;
    private float m_currentAccuracy;
    public float m_accuracy;
    public float m_accuracyRecoverPerSecond;
    public static Action<int,int> OnShot;
    public WeaponList listaArmas;
    private int armaActual;

    private void Start()
    {
        Weapon = listaArmas.weaponList[armaActual];
        m_municionActual = Weapon.m_ammoCapacity;
        m_TiempoEntreDisparos = 1 / Weapon.m_rateOfShot;
        ActivarModeloArma();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaActual = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaActual = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            armaActual = 2;
        }

        Weapon = listaArmas.weaponList[armaActual];

        ActivarModeloArma();

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
                    OnShot?.Invoke(m_municionActual, Weapon.m_ammoCapacity);

                }
                else
                {
                    m_municionActual = Weapon.m_ammoCapacity;
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
        Vector3 directionForward = Camera.main.transform.forward;
        directionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        m_currentAccuracy -= m_accuracyDropPerShot;
        m_currentAccuracy = Mathf.Clamp(m_currentAccuracy, 0, 100);

        Ray ray = new Ray(Camera.main.transform.position, directionForward);
        
        
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, Weapon.m_weaponRange))
        {
            Debug.Log("Hit " + hit.transform.name);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(ray.direction * Weapon.m_forceToApply);
                Debug.Log("Hit");
                
            }
            Enemy enemigo = hit.transform.GetComponent<Enemy>();
            if (enemigo != null)
            {
                Debug.Log("Hit enemigo");
                enemigo.RecibirDaño();
            }
        }
        Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 4);

        GetComponent<AudioSource>().PlayOneShot(Weapon.m_fireSound);
    }
    public void ActivarModeloArma()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            if (i-1 == armaActual)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
