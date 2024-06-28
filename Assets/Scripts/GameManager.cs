/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/28/2024
 * Description: Functions related to the game manager to save progress across scenes
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Store
    /// </summary>
    public static GameManager Instance;

    public float maxHealth;

    private float health;

    private bool isDead = false;

    public Image healthBarImage;
    public TextMeshProUGUI healthText;

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
    private void Start()
    {
        // Initialize health
        health = maxHealth;
        // GameManager shouldn't handle updating UI directly
    }
    public void TakeDamage(float attackDamage)
    {
        if (isDead) return;

        health -= attackDamage;
        float fillAmount = health / maxHealth;
        healthBarImage.fillAmount = fillAmount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; // Prevent multiple death triggers

        isDead = true;
        health = 0f;
        float fillAmount = health / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        Debug.Log("Player died");
    }
}
