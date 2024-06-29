using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
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