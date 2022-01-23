using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Name Weapon Info", menuName = "Weapon Info", order = 51)]
public class SimpleWeaponInfo : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private float m_damage = 80.0f;
    [SerializeField] private float m_forceToApply = 20.0f;
    [SerializeField] private float m_weaponRange = 9999.0f;
    [SerializeField] private int m_ammoCapacity = 12;
    [SerializeField] private float m_rateOfShot = 4;
    [SerializeField] private AudioClip m_fireSound;
    [SerializeField] private AudioClip m_realoadSound;

    public string Name { get => m_name; set => m_name = value; }
    public float Damage { get => m_damage; set => m_damage = value; }
    public float ForceToApply { get => m_forceToApply; set => m_forceToApply = value; }
    public float WeaponRange { get => m_weaponRange; set => m_weaponRange = value; }
    public int AmmoCapacity { get => m_ammoCapacity; set => m_ammoCapacity = value; }
    public float RateOfShot { get => m_rateOfShot; set => m_rateOfShot = value; }
    public AudioClip FireSound { get => m_fireSound; set => m_fireSound = value; }
    public AudioClip RealoadSound { get => m_realoadSound; set => m_realoadSound = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
