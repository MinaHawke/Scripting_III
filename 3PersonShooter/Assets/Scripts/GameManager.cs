using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    private FPSCharacterController player;
    ShootingEnemy[] enemigos;
    public FPSCharacterController Player { get {
            if (player == null)
            {
                player = FindObjectOfType<FPSCharacterController>();
            }
            return player;} set => player = value; }

    public bool AlarmaDada { get; set; }

    public void AlertarATodosLosEnemigos()
    {
        AlarmaDada = true;
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].agent.SetDestination(player.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        enemigos = FindObjectsOfType<ShootingEnemy>();
    }

   public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
