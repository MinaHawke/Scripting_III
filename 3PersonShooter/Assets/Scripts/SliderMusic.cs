using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour
{
    public bool isSFX;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(GuardarValor);
    }

    private void GuardarValor(float valor)
    {
        if (isSFX)
        {
            MusicManager.Instance.SfxVolume = valor;
        }
        else
        {
            MusicManager.Instance.MusicVolume = valor;
        }
    }
}
