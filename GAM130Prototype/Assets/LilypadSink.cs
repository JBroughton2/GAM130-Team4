using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadSink : MonoBehaviour
{
    [Header("Sinking Speed & Rising Speed")]
    [SerializeField]
    private float sinkSpeed;
    [SerializeField]
    private float riseSpeed;

    [Header("Can the pad rise back up?")]
    [SerializeField]
    private bool lilypadRise;

    [Header("Lilypad Rise Delay")]
    [SerializeField]
    private float delay;

    private Vector3 currentPos;
    private Vector3 startingPos;
    private Transform pad;
    private bool delayFinished;

    void Start()
    {
        pad = this.gameObject.transform;
        currentPos = pad.position;
        startingPos = currentPos;
        delayFinished = false;
    }

    void FixedUpdate()
    {
        if (currentPos.y <= startingPos.y && delayFinished)
        {
            currentPos.y += riseSpeed;
            pad.position = currentPos;
        }
        if(currentPos.y >= startingPos.y)
        {
            delayFinished = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            currentPos.y -= sinkSpeed;
            pad.position = currentPos;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && lilypadRise)
        {
            StartCoroutine(RiseLilypad());
        }
    }

    IEnumerator RiseLilypad()
    {
        pad.position = currentPos;
        yield return new WaitForSeconds(delay);
        delayFinished = true;
    }

}
