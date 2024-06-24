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
        // Destroy the attached GameObject
        Destroy(gameObject);
       //Test
    }
}
