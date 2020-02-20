using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    // public AudioClip deathClip;

    bool isDead;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage()
    {

    }

}
