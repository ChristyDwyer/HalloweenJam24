using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField][Range(0.0f, 1f)] private float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.GetInt("SettingsEnabled"))
        {
            if (PlayerPrefs.HasKey("GlobalVolume")) { volume = PlayerPrefs.GetFloat("GlobalVolume"); }
            Debug.Log("Hi I'm starting and the volume is "+ volume);
            PlayerPrefs.SetInt("SettingsEnabled", 1);
            PlayerPrefs.SetFloat("GlobalVolume", volume);
            AudioListener.volume = (PlayerPrefs.GetFloat("GlobalVolume"));
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (AudioListener.volume != volume)
        {
            PlayerPrefs.SetFloat("GlobalVolume", volume);
            Debug.Log("Volume changed to "+ AudioListener.volume);
            AudioListener.volume = (PlayerPrefs.GetFloat("GlobalVolume"));
        }
    }
}
