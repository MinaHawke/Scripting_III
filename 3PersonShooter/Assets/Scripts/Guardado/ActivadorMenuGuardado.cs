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
            Cursor.visible = !Cursor.visible;
            canvasGuardado.SetActive(!canvasGuardado.activeSelf);
        }
    }
}