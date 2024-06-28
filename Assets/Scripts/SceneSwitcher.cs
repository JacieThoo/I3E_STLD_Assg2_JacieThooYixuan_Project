/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/26/2024
 * Description: Functions related to the scene switching
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : Interactable
{   
    /// <summary>
    /// Scene to change to
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Overridde base function and interact to change scene
    /// </summary>
    /// <param name="thePlayer"></param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Call the ChangeScene() function
        ChangeScene();
    }

    /// <summary>
    /// Functionality to change to new target scene
    /// </summary>
    void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}