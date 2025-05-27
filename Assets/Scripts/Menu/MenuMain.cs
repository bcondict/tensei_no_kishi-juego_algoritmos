using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMain: MonoBehaviour 
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }
}
