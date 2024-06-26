/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/26/2024
 * Description: Functions related to the crate that will spawn a collectible after interacted with
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
    /// override base interact function
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class
        base.Interact(thePlayer);

        SpawnCollectible();
        //Destroy crate after spawning collectible
        Destroy(gameObject);
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
}
