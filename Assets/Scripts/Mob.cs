/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/27/2024
 * Description: Functions related to mobs, including health bar and death
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mob : MonoBehaviour
{   
    /// <summary>
    /// Original health of the mob
    /// </summary>
    public float maxHealth;

    /// <summary>
    /// Current health of the mob
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// Stores the green (mob health left until death) of the health bar
    /// </summary>
    public Image healthBarImage;

    /// <summary>
    /// Update the health bar when the game starts
    /// </summary>
    void Start()
    {
        // Set original health to max
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    /// <summary>
    /// Deducts health points from mob and updates the health bar
    /// Mob dies when health points is 0
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage (float damage)
    {
        // Deduct health
        currentHealth -= damage;

        // Update health bar after deducting health
        UpdateHealthBar ();
        
        // When mob dies
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    /// <summary>
    /// When mob dies, mob object gets destroyed
    /// </summary>
    void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// To update health bar according to the current health out of max health
    /// </summary>
    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }
}