using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
        StartCoroutine(ZombieDie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ZombieDie()
    {
        yield return new WaitForSeconds(1.3f);

        animator.SetBool("Dying", true);

        yield return new WaitForSeconds(6f);

        winUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


    }
}
