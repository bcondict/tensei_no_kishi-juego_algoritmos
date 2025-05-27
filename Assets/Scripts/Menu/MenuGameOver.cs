using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuGameOver : MonoBehaviour 
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuPrincipal(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
