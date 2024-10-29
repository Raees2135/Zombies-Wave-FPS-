using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject cutSceneCam;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(13f);

        cutSceneCam.SetActive(false);

    }
}
