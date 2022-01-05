using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{
    Image image;

    private void OnEnable()
    {
        FPSCharacterController.OnDamageTaken += UpdateHealthbar;
    }

    private void UpdateHealthbar()
    {
        if (!image)
            image = GetComponent<Image>();

        image.fillAmount = GameManager.Instance.Player.m_health / (float)GameManager.Instance.Player.m_maxHealth;
    }

    private void OnDisable()
    {
        FPSCharacterController.OnDamageTaken -= UpdateHealthbar;
    }
}
