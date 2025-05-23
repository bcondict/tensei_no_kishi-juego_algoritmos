using UnityEngine;
using UnityEngine.UI;


public class CodFullScreen: MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    void Update()
    {

    }
    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
}
