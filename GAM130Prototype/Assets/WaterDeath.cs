using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterDeath : MonoBehaviour
{
    [SerializeField]
    private Transform checkpoint;
    [SerializeField]
    private GameObject fadeToBlack;
    private float delay = 0.5f;

    void OnTriggerEnter(Collider col)
    {
        fadeToBlack.SetActive(true);
        col.transform.position = checkpoint.position;
        StartCoroutine(fadeDelay());
    }

    IEnumerator fadeDelay()
    {
        yield return new WaitForSeconds(delay);
        fadeToBlack.SetActive(false);
    }

}
