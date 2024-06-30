/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/24/2024
 * Description: Functions related to the player
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    /// <summary>
    /// Where to raycast from
    /// </summary>
    [SerializeField]
    Transform playerCamera;

    /// <summary>
    /// Distance to raycast
    /// </summary>
    [SerializeField]
    float interactionDistance;

    /// <summary>
    /// Text to state what key to interact with, used in UI
    /// </summary>
    [SerializeField]
    TextMeshProUGUI interactionText;

    /// <summary>
    /// Raycasting for all interactables
    /// </summary>
    private void Update()
    {
        //for raycast line, easier to see
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                //show text when looking at object with raycast
                //interactionText.gameObject.SetActive(true);
            }
            else
            {
                //currentInteractable = null;
                //interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            //currentInteractable = null;
            //interactionText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Callback function for the Interact input action
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if (currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}