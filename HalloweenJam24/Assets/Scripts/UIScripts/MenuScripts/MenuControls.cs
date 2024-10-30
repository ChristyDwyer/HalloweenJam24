using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{

    [SerializeField] private GameObject volumeSlider = null, volumeControlHolder = null, menuHolder = null, creditsHolder = null, pauseMenu = null;

    [SerializeField] private PlayerInput controls = null;

    public void loadGame()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }

    private void Start()
    {
        //controls.PlayerControls.Pause.performed += _ => OnPause();
        InputSystem.actions.FindAction("Pause");
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

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void pause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void unPause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
