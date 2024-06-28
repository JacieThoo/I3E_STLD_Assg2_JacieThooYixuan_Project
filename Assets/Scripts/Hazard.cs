/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/28/2024
 * Description: Functions related to the hazards
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    /// <summary>
    /// The amount of damage the hazard does
    /// </summary>
    public float hazardDamage;

    /// <summary>
    /// Damage the player when player collides with the hazard
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.TakeDamage(hazardDamage);
    }
}