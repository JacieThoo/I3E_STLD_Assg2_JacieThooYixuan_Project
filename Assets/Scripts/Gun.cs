/*
 * Author: Jacie Thoo Yixuan
 * Date: 06/27/2024
 * Description: Functions related to the gun
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// How much damage the gun deals
    /// </summary>
    public float damage;

    /// <summary>
    /// The range of the gun, how far it cn shoot
    /// </summary>
    public float range;

    /// <summary>
    /// Stores the camera where ray casting starts from
    /// </summary>
    public Camera fpsCam;

    /// <summary>
    /// Particle for the muzzle we
    /// </summary>
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    /// <summary>
    /// Call Shoot() when using left click
    /// </summary>
    void Update()
    {
        // Unity input for Fire1 is left click
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Handles shooting mechanics
    /// </summary>
    public void Shoot()
    {
        // Draw line to show the ray cast
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.green, 2f);

        // Play muzzle particle
        muzzleFlash.Play();

        // Raycast to see if there is an object where the player hits within the range
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // Check if object is mob
            Mob mob = hit.transform.GetComponent<Mob>();
            if (mob != null )
            {
                // Mob takes damage
                mob.TakeDamage(damage);
            }

            // Check if object is breakable
            Breakable breakable = hit.transform.GetComponent<Breakable>();
            if (breakable != null)
            {
                breakable.TakeDamage(damage);
            }

            //Check if object is a crate
            Crate crate = hit.transform.GetComponent<Crate>();
            if (crate != null)
            {
                crate.TakeDamage(damage);
            }
        }
    }
}