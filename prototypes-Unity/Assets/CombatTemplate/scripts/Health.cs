using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void AddToMaxHealth(int am)
    {
        MaxHealth += am;
    }

    public void AddToCurrentHealth(int a)
    {
        CurrentHealth += a;
    }

    public void TakeDamage(int d)
    {
        CurrentHealth -= d;
        if(CurrentHealth <= 0)
        {
            //Play death animation.
            //Then Die.
            Debug.Log("Entity is dead.");
        }
    }
}
