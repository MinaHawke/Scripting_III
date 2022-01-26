using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;
 

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(PantallaCarga);
        ExitButton.onClick.AddListener(CerrarJuego);
    }


    private void PantallaCarga()
    {
        SceneManager.LoadScene("PantallaCarga");
    }
    private void CerrarJuego()
    {
        Application.Quit();
    }
}
