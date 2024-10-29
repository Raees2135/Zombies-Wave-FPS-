using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject hitEffectPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    // Function to handle shooting
    void Shoot()
    {
        // Implement shooting behavior (e.g., raycasting, instantiate bullets)
        // For this example, we'll use a raycast to deal damage to whatever the gun hits.

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            Debug.Log("We hit" + hit.collider.name);


            GameObject obj = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(obj, 2f);

            DamageHandler damageHandler = hit.transform.GetComponent<DamageHandler>();

            if (damageHandler != null)
            {
                damageHandler.DealDamage(hit.transform.gameObject);
            }
        }
    }
}
