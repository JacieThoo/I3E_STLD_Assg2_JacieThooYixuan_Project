using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{

    public int healthPoints = 100;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        healthPoints -= damageAmount;
        if (healthPoints <= 0)
        {
            //play death animation
            animator.SetTrigger("die");
        }
        else
        {
            //play get attacked animation
        }
    }
}
