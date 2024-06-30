/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/28/2024
 * Description: Functions related to the broken crystal
 */

using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BrokenCrystal : Interactable
{
    /// <summary>
    /// Override Interact()from Interactable base class
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Attempt to place special collectible
        PlaceSpecialCollectible();
        SceneManager.LoadScene(6);
    }

    /// <summary>
    /// Handle the placement of the special collectible
    /// </summary>
    public void PlaceSpecialCollectible()
    {
        // Check if special collectible has been collected
        if (GameManager.Instance.IsSpecialCollectibleCollected)
        {
            Debug.Log("Special collectible placed");
        }
        else
        {
            Debug.Log("Cannot place the special collectible yet");
        }
    }
}