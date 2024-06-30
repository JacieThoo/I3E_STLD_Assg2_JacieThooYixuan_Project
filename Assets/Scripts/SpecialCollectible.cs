/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/28/2024
 * Description: Functions related to the special collectible
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpecialCollectible : Interactable
{
    /// <summary>
    ///  Reference to the BrokenCrystal instance, where the special collectible needs to be placed
    /// </summary>
    public BrokenCrystal brokenCrystal;
    
    /// <summary>
    /// Audio for when collectible is collected
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Override Interact()from Interactable base class
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Call the Collected() function
        Collected();
    }

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public void Collected()
    {
        // Play audio at position when collected
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

        // Tells the GameManager that special collectible has been collected
        GameManager.Instance.CollectSpecialCollectible();

        Debug.Log("Collected special collectible");

        // Destroy the attached GameObject
        Destroy(gameObject);
    }
}