using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int damageAmount = 10;

    // Function to apply damage to an enemy
    public void DealDamage(GameObject target)
    {
        HealthController healthController = target.GetComponent<HealthController>();

        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);
        }
    }
}
