using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public float health = 10;
    public Animator animator;
    public KillCountManager killCountManager;
 

    private void Start()
    {
       killCountManager = FindAnyObjectByType<KillCountManager>();
    }

    public void Damage(float damage)
    {
        health -= damage;

        if(health <= damage)
        {
            StartCoroutine(Die());
        }
 
    }

    IEnumerator Die()
    {
        animator.SetInteger("action", 1);

        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
        killCountManager.IncrementKillCount();

    }
}
