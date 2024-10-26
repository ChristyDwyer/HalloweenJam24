using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{

    [SerializeField] private GameObject volumeSlider = null, volumeControlHolder = null, menuHolder = null, creditsHolder = null;
    public void loadGame()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }
    public void viewSettings()
    {
        if (menuHolder != null) 
        {
            menuHolder.SetActive(false);
        }
        if (volumeControlHolder != null)
        {
            volumeControlHolder.SetActive(true);
        }

        if (volumeSlider != null)
        {
            volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("GlobalVolume");
        }
    }

    public void viewCredits()
    {
        if (menuHolder != null)
        {
            menuHolder.SetActive(false);
        }

        if (creditsHolder != null)
        {
            creditsHolder.SetActive(true);
        }
    }

    public void returnToMenu()
    {
        if (menuHolder != null)
        {
            menuHolder.SetActive(true);
        }
        if (volumeControlHolder != null)
        {
            volumeControlHolder.SetActive(false);
        }
        if (creditsHolder != null)
        {
            creditsHolder.SetActive(false);
        }
    }

    public void volumeChange()
    {
        float volume = volumeSlider.GetComponent<Slider>().value;

        PlayerPrefs.SetFloat("GlobalVolume", volume);
        PlayerPrefs.Save();
    }
}
