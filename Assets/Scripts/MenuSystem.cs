/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/29/2024
 * Description: Functions related to the menu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    /// <summary>
    /// Reference to the main menu canvas
    /// </summary>
    public Canvas menu;

    /// <summary>
    /// Reference to the options canvas
    /// </summary>
    public Canvas options;

    /// <summary>
    /// Reference to the how to play canvas
    /// </summary>
    public Canvas howToPlay;

    /// <summary>
    /// Reference to the credits canvas
    /// </summary>
    public Canvas credits;

    /// <summary>
    /// Reference to audio source for background music
    /// </summary>
    public AudioSource backgroundMusicSource;

    /// <summary>
    /// Reference to slider for adjusting BG music volume
    /// </summary>
    public Slider volumeSlider;

    /// <summary>
    /// Reference to UI for game manager
    /// </summary>
    public GameObject gameManagerUI;

    /// <summary>
    /// Set slider value when  script instance being loaded
    /// </summary>
    private void Awake()
    {
        // Set initial slider value
        if (volumeSlider != null && backgroundMusicSource != null)
        {
            volumeSlider.value = backgroundMusicSource.volume;
        }

        // Listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    /// <summary>
    /// Initialise menu
    /// Set menu active, other pages inactive
    /// </summary>
    private void Start()
    {
        menu.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    /// <summary>
    /// Starts game by loading first scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (gameManagerUI != null)
        {
            gameManagerUI.SetActive(true);
        }
    }

    /// <summary>
    /// Quits application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Opens menu page and hide other pages
    /// </summary>
    public void OpenMenu()
    {
        menu.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    /// <summary>
    /// Opens options page and hide other pages
    /// </summary>
    public void OpenOptions()
    {
        menu.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
        howToPlay.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    /// <summary>
    /// Opens how to play page and hide other pages
    /// </summary>
    public void OpenHowToPlay()
    {
        menu.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
    }

    /// <summary>
    /// Opens credits page and hide other pages
    /// </summary>
    public void OpenCredits()
    {
        menu.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    /// <summary>
    /// Set volume for BG music 
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.volume = volume;
        }
    }

    /// <summary>
    /// When volume slider value changes, this function is called
    /// </summary>
    /// <param name="value"></param>
    private void OnVolumeSliderChanged(float value)
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.volume = value;
        }
    }
}