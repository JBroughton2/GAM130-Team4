using UnityEngine;

public class LightCycle : MonoBehaviour
{

    [SerializeField]
    public float secondsInDay = 360f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, (secondsInDay / 60f) * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
