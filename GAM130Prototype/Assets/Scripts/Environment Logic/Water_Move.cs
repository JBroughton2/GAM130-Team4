using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Move : MonoBehaviour
{

    public static float speedX = 0.1f;
    public static float speedY = 0.1f;
    private static float curX;
    private static float curY;
    private static bool changing = true;
    private static float delay = 2f;

    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;

    }

    void FixedUpdate()
    {
        if (changing)
        {
            StartCoroutine(changeSpeed());
            speedX = Random.Range(-0.01f, 0.01f);
            speedY = Random.Range(-0.01f, 0.01f);
            changing = false;
        }
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));
    }

    IEnumerator changeSpeed()
    {
        yield return new WaitForSeconds(delay);
        changing = true;
    }
}
