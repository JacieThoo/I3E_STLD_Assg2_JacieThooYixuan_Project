using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Execute the object's interaction
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object</param>
    public virtual void Interact(Player thePlayer)
    {
        Debug.Log(gameObject.name + " was interacted with.");
    }
}
