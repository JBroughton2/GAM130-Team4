using UnityEngine;

public class LightCycle : MonoBehaviour
{

    [SerializeField]
    public float secondsInDay = 360f;

    [Range(0, 1)]
    public float currentTime = 0;
    public float timeMultiplier = 1f;


    void Start()
    {

    }

    void Update()
    {
        currentTime += (Time.deltaTime / secondsInDay) * timeMultiplier;
        if (currentTime >= 1)
        {
            currentTime = 0;
        }

        transform.RotateAround(Vector3.zero, Vector3.right, (60f / secondsInDay) * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
