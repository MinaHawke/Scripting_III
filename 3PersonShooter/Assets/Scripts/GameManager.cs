using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    private FPSCharacterController player;

    public FPSCharacterController Player { get {
            if (player == null)
            {
                player = FindObjectOfType<FPSCharacterController>();
            }
            return player;} set => player = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
