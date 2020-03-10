using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
        // Variables
    private int maxOxygen = 100;
    private int currentOxygen;
    public int poisonDamage = 3;
    public int oxygenPack = 30;

    // References to the OxygenBar

    // Booleans
    public bool isBeingPoisoned;


    // public AudioClip deathClip;

    bool isDead;

    void Awake()
    {
        currentOxygen = maxOxygen;

    }

    public void TakeDamage(int amount)
    {
        currentOxygen -= amount;

        if (currentOxygen <= 0 && !isDead)
        {
            Death();
        }
    }

    void IncreaseOxygen()
    {
        if (currentOxygen + oxygenPack > maxOxygen)
            currentOxygen = maxOxygen;
        else
            currentOxygen = currentOxygen + oxygenPack;
    }

    void DecreasingOxygen()
    {
        isBeingPoisoned = inPoisonusZone();
    }

    bool inPoisonusZone()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, Radius);
        foreach (Collider item in nearbyObjects)
        {
            if (item.CompareTag("PoisonusPlant"))
            {
                target = item.transform;
                return true;
            }
        }
        return false;
    }

    void Death()
    {
        isDead = true;
    }
}
