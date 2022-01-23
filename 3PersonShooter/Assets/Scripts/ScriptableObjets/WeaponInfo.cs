using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponInfo
{
    public string m_name;
    public float m_damage = 80.0f;
    public float m_forceToApply = 20.0f;
    public float m_weaponRange = 9999.0f;
    public int m_ammoCapacity = 12;
    public float m_rateOfShot = 4;
    public AudioClip m_fireSound;
    public AudioClip m_realoadSound;
    public bool m_isAShotgun;
}
