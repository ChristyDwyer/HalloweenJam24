using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField][Range(0.0f, 1f)] private float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        {
            if (PlayerPrefs.HasKey("GlobalVolume"))
            {
                volume = PlayerPrefs.GetFloat("GlobalVolume");
            }
            else volume = 0.01f;
            Debug.Log("Hi I'm starting and the volume is "+ volume);
            PlayerPrefs.SetInt("SettingsEnabled", 1);
            AudioListener.volume = (PlayerPrefs.GetFloat("GlobalVolume"));
            PlayerPrefs.Save();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (AudioListener.volume != volume)
        {
           
            PlayerPrefs.SetFloat("GlobalVolume", volume);
            float temp = PlayerPrefs.GetFloat("GlobalVolume");
            AudioListener.volume = temp;
            Debug.Log(temp);

            PlayerPrefs.Save();
        }
    }
}
