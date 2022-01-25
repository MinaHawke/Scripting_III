using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
	public void SaveGameScene ()
    {
        Enemy[] enemigos = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].GuardarVida();
        }

    }

    public void LoadGameScene ()
    {
        GameManager.Instance.CargarDatos();
	}
}
