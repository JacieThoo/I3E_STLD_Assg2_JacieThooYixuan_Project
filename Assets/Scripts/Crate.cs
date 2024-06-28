/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/26/2024
 * Description: Functions related to the crate that will spawn a collectible after being shot at
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Interactable
{
    /// <summary>
    /// Collectible to spawn after interacting with crate
    /// </summary>
    [SerializeField]
    private GameObject collectibleToSpawn;

    /// <summary>
    /// Sound effect that plays after interacting with the crate
    /// </summary>
    [SerializeField]
    private AudioClip crateAudio;

    /// <summary>
    /// Health of the crate
    /// </summary>
    public float health;

    /// <summary>
    /// Field to hold BoxCollider
    /// </summary>
    BoxCollider bc;

    /// <summary>
    /// Get BoxCollider component and store in bc when gaame starts
    /// </summary>
    private void Awake()
    {
        bc = GetComponent<BoxCollider>();
    }

    /// <summary>
    /// Play audio for interacting with crate
    /// Spawn collectible
    /// </summary>
    void SpawnCollectible()
    {
        AudioSource.PlayClipAtPoint(crateAudio, transform.position, 1f);
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }

    /// <summary>
    /// Crate takes damage and breaks when health becomes 0
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        // Deduct health from gun damage
        health -= amount;
        if (health <= 0f)
        {
            SpawnCollectible();
            Destroy(gameObject);
        }
    }
}