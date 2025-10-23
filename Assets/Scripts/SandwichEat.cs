using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandwichEat : MonoBehaviour
{
    public TextMeshProUGUI healthBar;

    private int health = 5;
    private int maxHealth = 5;
    private float cooldown = 0.25f;
    private float lastDamage;

    void Start()
    {
        health = maxHealth;
        healthBar.text = $"Health: {health:0}/{maxHealth:0}";
        lastDamage = -cooldown;

    }

    // this is broken rn
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug") && Time.time >= lastDamage + cooldown)
        {
            health--;
            lastDamage = Time.time;
            Debug.Log("Bug ate sandwich!");
            healthBar.text = $"Health: {health}/{maxHealth}";
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Debug.Log("Sandwich destroyed!");
            }
        }
    }

    void Update()
    {
        
    }
}
