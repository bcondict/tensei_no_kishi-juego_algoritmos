using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu: MonoBehaviour 
{

    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("saliendo del juego");
    }
}
