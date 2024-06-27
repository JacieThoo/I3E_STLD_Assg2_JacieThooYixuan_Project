/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/25/2024
 * Description: Functions related to the breakable fence
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Breakable : Interactable
{
    /// <summary>
    /// Field to hold normal intact fence
    /// </summary>
    [SerializeField]
    GameObject intactFence;

    /// <summary>
    /// Field to hold broken fence
    /// </summary>
    [SerializeField]
    GameObject brokenFence;

    /// <summary>
    /// Field to hold BoxCollider
    /// </summary>
    BoxCollider bc;

    public float health;

    /// <summary>
    /// Hide broken fence and show normal fence when game starts
    /// </summary>
    private void Awake()
    {
        //Show normal fence
        intactFence.SetActive(true);

        //Hide broken fence
        brokenFence.SetActive(false);

        //Get BoxCollider component and store in bc
        bc = GetComponent<BoxCollider>();
    }

    /// <summary>
    /// Simulate breaking of fence
    /// </summary>
    private void BreakFence()
    {
        //Hide normal fence
        intactFence.SetActive(false);

        //Show broken fence
        brokenFence.SetActive(true);

        //Disable the BoxCollider to prevent any more interactions after broken
        bc.enabled = false;
    }

    /// <summary>
    /// Break fence when hit with gun
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        // Deduct health from gun damage
        health -= amount;
        if (health <= 0f) 
        {
            BreakFence();
        }
    }
}