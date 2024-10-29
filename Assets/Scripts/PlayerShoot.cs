using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon[] weapon;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffectPrefab;
    public AudioSource shootSound;

    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;

    public PlayerWeapon playerWeapon;



    // Start is called before the first frame update
    void Start()
    {

        if (cam == null)
        {
            Debug.Log("No camera referrenced");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
          
            Shoot();
           
        }
        
    }

    void Shoot()
    {
        muzzleFlash.Play();
        shootSound.Play();

        RaycastHit hit;



        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerWeapon.range, mask))
        {
            

            Debug.Log("We hit" + hit.collider.name);
            

            GameObject obj = Instantiate(hitEffectPrefab,hit.point,Quaternion.LookRotation(hit.normal));

            Destroy(obj, 2f);

            Hit enemy = hit.transform.GetComponent<Hit>();

            if(enemy != null)
            {
                enemy.Damage(2);

            }

        }

    }

    


}
