using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAttack : MonoBehaviour
{
    private int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(damage);
    }
}
