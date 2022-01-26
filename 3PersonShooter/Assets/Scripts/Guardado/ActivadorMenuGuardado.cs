using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorMenuGuardado : MonoBehaviour
{
    [SerializeField] GameObject canvasGuardado;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvasGuardado.SetActive(!canvasGuardado.activeSelf);
        }
    }
}