using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIAmmo : MonoBehaviour
{
    TextMeshProUGUI tmpro;

    private void OnEnable()
    {
        VerySimplePistol.OnShot += UpdateAmmo;
    }

    private void UpdateAmmo(int munActual, int munMaxima)
    {
        if (!tmpro)
            tmpro = GetComponent<TextMeshProUGUI>();

        tmpro.text = munActual + "/" + munMaxima;
    }

    private void OnDisable()
    {
        VerySimplePistol.OnShot -= UpdateAmmo;
    }
}
