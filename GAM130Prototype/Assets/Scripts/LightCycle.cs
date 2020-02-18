using UnityEngine;

public class LightCycle : MonoBehaviour
{

    [SerializeField]
    public float secondsInDay = 360f;

    [Range(0, 1)]
    public float currentTime = 0;
    public float timeMultiplier = 1f;

    float sunInitialIntensity;
    float moonInitialIntensity;

    void Start()
    {
        GameObject sun = this.gameObject;
        GameObject moon = this.gameObject;

        

        sunInitialIntensity = sun.intensity;
        moonInitialIntensity = moon.intensity;
    }
    void Update()
    {
        UpdateSun();
        UpdateMoon();

        currentTime += (Time.deltaTime / secondsInDay) * timeMultiplier;
        if (currentTime >= 1)
        {
            currentTime = 0;
        }

        transform.RotateAround(Vector3.zero, Vector3.right, (60f / secondsInDay) * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }

    void UpdateSun()
    {
        float intensityMultiplier = 1;
        if (currentTime <= 0.23f || currentTime >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTime <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
        }
        else if (currentTime >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    void UpdateMoon()
    {
        float intensityMultiplier = 1;
        if (currentTime <= 0.23f || currentTime >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTime <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
        }
        else if (currentTime >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
        }

        moon.intensity = moonInitialIntensity * intensityMultiplier;
    }
}
