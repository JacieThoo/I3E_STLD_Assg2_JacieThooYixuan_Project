/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/28/2024
 * Description: Functions related to the game manager to save progress across scenes
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// To make sure there is only 1 game manager
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// Stores the total amount of health the player has
    /// </summary>
    public float maxHealth;

    /// <summary>
    /// Stores the current health of the player
    /// </summary>
    private float health;

    /// <summary>
    /// Check if the player is dead
    /// </summary>
    private bool isDead = false;

    /// <summary>
    /// To store the image of the health bar for the player's current health
    /// </summary>
    public Image healthBarImage;

    /// <summary>
    /// Stores the player's current health in text
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// To check if the special collectible is collected
    /// </summary>
    public bool IsSpecialCollectibleCollected;

    /// <summary>
    /// Reference to pause menu UI
    /// </summary>
    public GameObject pauseMenuUI;

    /// <summary>
    /// Check if the game is paused
    /// </summary>
    private bool isPaused = false;

    /// <summary>
    /// Reference to game manager UI
    /// </summary>
    public GameObject gameManagerUI;

    /// <summary>
    /// Count metal collectibles
    /// </summary>
    public int totalMetalCollected = 0;

    /// <summary>
    /// Text to display amt of collected metal
    /// </summary>
    public TextMeshProUGUI metalCountText;

    /// <summary>
    /// Count potion collectibles
    /// </summary>
    public int totalPotionCollected;

    /// <summary>
    /// Text to display amt of collected potions
    /// </summary>
    public TextMeshProUGUI potionCountText;

    /// <summary>
    /// Count battery collectibles
    /// </summary>
    public int totalBatteryCollected;

    /// <summary>
    /// Text to display amt of collected batteries
    /// </summary>
    public TextMeshProUGUI batteryCountText;

    /// <summary>
    /// Reference to death menu UI
    /// </summary>
    public GameObject deathMenuUI;

    /// <summary>
    /// Make sure there is only 1 game manager instance
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// initialise health and deactivate pause and game manager ui
    /// </summary>
    private void Start()
    {
        // Initialize health
        health = maxHealth;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        if (gameManagerUI != null)
        {
            gameManagerUI.SetActive(false);
        }
    }

    /// <summary>
    /// Reduces player's health by the specified attack damage
    /// </summary>
    /// <param name="attackDamage"></param>
    public void TakeDamage(float attackDamage)
    {
        if (isDead) return;

        health -= attackDamage;
        float fillAmount = health / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        healthText.text = health.ToString();

        if (health <= 0f)
        {
            Die();
        }
    }

    /// <summary>
    /// Handdle player death
    /// </summary>
    void Die()
    {
        if (isDead) return; // Prevent multiple death triggers

        isDead = true;
        health = 0f;
        float fillAmount = health / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        healthText.text = health.ToString();
        Debug.Log("Player died");

        if (pauseMenuUI != null)
        {
            deathMenuUI.SetActive(true);
        }
    }

    /// <summary>
    /// Handle player respawn
    /// </summary>
    public void Respawn()
    {
        // Reset health
        health = maxHealth;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reset the death state
        isDead = false;

        // Update the health UI after the scene reloads
        UpdateHealthUI();

        if (pauseMenuUI != null)
        {
            deathMenuUI.SetActive(false);
        }

        if (isPaused)
        {
            Resume();
        }
    }

    /// <summary>
    /// Updates health UI
    /// </summary>
    private void UpdateHealthUI()
    {
        float fillAmount = health / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        healthText.text = health.ToString();
    }

    /// <summary>
    /// Marks the special collectible as collected.
    /// </summary>
    public void CollectSpecialCollectible()
    {
        IsSpecialCollectibleCollected = true;
    }

    /// <summary>
    /// To open pause menu
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Resumes the game from a paused state
    /// </summary>
    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Debug.Log("Game resumed");
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    /// <summary>
    /// Pauses the game and show the pause menu
    /// </summary>
    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        isPaused = true;
    }

    /// <summary>
    /// Loads the main menu scene
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
    }

    /// <summary>
    /// Quits the application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Updates the count of collected metal and refreshes the UI.
    /// </summary>
    public void UpdateMetalCount()
    {
        totalMetalCollected++;
        metalCountText.text = "Metal: " + totalMetalCollected.ToString();
    }

    /// <summary>
    /// Updates the count of collected potions and refreshes the UI.
    /// </summary>
    public void UpdatePotionCount()
    {
        totalPotionCollected++;
        potionCountText.text = "Potions: " + totalPotionCollected.ToString();
    }

    /// <summary>
    /// Updates the count of collected batteries and refreshes the UI.
    /// </summary>
    public void UpdateBatteryCount()
    {
        totalBatteryCollected++;
        batteryCountText.text = "Batteries: " + totalBatteryCollected.ToString();
    }
}