using UnityEngine;
using UnityEngine.UI;

public class CodVolumen : MonoBehaviour
{
    public static CodVolumen Instance { get; private set; }

    [Header("UI")]
    public Slider slider;
    public Image imageMute;

    const string PREF_KEY = "volumenAudio";
    const float DEFAULT_VOL = 0.5f;

    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
        float vol = PlayerPrefs.GetFloat(PREF_KEY, DEFAULT_VOL);
        AudioListener.volume = vol;
    }

    void Start()
    {
        
        slider.value = AudioListener.volume;
        RevisarSiEstoyMute();
    }

  
    public void ChangeSlider(float valor)
    {
        slider.value = valor;
        AudioListener.volume = valor;

       
        PlayerPrefs.SetFloat(PREF_KEY, valor);
        PlayerPrefs.Save();

        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        imageMute.enabled = (slider.value == 0f);
    }
}