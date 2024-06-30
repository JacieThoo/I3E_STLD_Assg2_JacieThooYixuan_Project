/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/24/2024
 * Description: Functions related to the normal collectibles
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCollectible : Interactable
{
    /// <summary>
    /// Audio for when collectible is collected
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Override base interact function
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
        //play audio at position when collected
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

        if (gameObject.tag == "Metal")
        {
            GameManager.Instance.UpdateMetalCount();
        }
        else if (gameObject.tag == "Potion")
        {
            GameManager.Instance.UpdatePotionCount();
        }
        else if (gameObject.tag == "Battery")
        {
            GameManager.Instance.UpdateBatteryCount();
        }

        // Destroy the attached GameObject
        Destroy(gameObject);
    }
}