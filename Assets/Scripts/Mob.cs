using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    float healthPoints;

    public void TakeDamage(int damageAmount)
    {
        healthPoints -= damageAmount;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
