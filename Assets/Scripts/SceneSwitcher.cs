/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/26/2024
 * Description: Functions related to the scene switcher
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    /// <summary>
    /// Scene that should be loaded
    /// Defined in inspector
    /// </summary>
    public int sceneName;

    /// <summary>
    /// When a player collides, call function to change scene
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(sceneName);
    }
}
