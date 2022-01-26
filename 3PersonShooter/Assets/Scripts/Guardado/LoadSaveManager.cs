using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    //public static bool GameIsPaused = false;
    //public GameObject CanvasMenu;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        if (GameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //            Pause();
    //    }
    //}

    public class ActivadorMenuGuardado
    {
        [SerializeField] GameObject canvasGuardado;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvasGuardado.SetActive(!canvasGuardado.activeSelf);
            }
        }
    }

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

    //void Pause()
    //{
    //    CanvasMenu.SetActive(true);
    //    Time.timeScale = 0f;
    //    GameIsPaused = true;
    //}
    //void Resume()
    //{
    //    CanvasMenu.SetActive(false);
    //    Time.timeScale = 1f;
    //    GameIsPaused = false;
    //}
}
