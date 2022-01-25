using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    private FPSCharacterController player;
    public ShootingEnemy[] enemigos;
    public Transform[] enemigosPosicion;
    public ShootingEnemy enemigoPrefab;
    public Transform[] puntosPatrulla;
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
        this.enemigos = new ShootingEnemy[enemigosPosicion.Length];
        for (int i = 0; i < enemigosPosicion.Length; i++)
        {
            ShootingEnemy enemigocreado = Instantiate(enemigoPrefab, enemigosPosicion[i].position, Quaternion.identity);
            enemigocreado.SetPatrolPoints(puntosPatrulla[i]);
            this.enemigos[i] = enemigocreado;
        }
    }

    public void CargarDatos()
    {
        Enemy[] enemigos = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemigos.Length; i++)
        {
            Destroy(enemigos[i].gameObject);
        }

        for (int i = 0; i < enemigosPosicion.Length; i++)
        {
            int vidaEnemigo = PlayerPrefs.GetInt("" + i);
            if (vidaEnemigo > 0)
            {
                ShootingEnemy enemigocreado = Instantiate(enemigoPrefab, enemigosPosicion[i].position, Quaternion.identity);
                enemigocreado.enemyActualHp = vidaEnemigo;
                this.enemigos[i] = enemigocreado;
                enemigocreado.SetPatrolPoints(puntosPatrulla[i]);
            }
        }
        Player.m_health = PlayerPrefs.GetInt("Vida Jugador");
        Player.GetComponentInChildren<VerySimplePistol>().m_municionActual = PlayerPrefs.GetInt("Municion Actual");
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
