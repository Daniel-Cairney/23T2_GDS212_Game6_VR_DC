using UnityEngine;
using UnityEngine.UI;
namespace DanielCairney
{
    public class CatHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
        public Slider healthBar;
        public AudioSource catHitSound;
        
        private void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject); // Destroy the enemy upon collision
                TakeDamage(10); // Adjust the damage amount as needed
            }
        }

        private void TakeDamage(int damage)
        {
            currentHealth -= damage;
            catHitSound.Play();
            if (currentHealth <= 0)
            {
                Die();
            }

            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            Debug.Log("YUIPPPYRPT");
            // Calculate the fill amount of the health bar image based on health changes
            float fillAmount = (float)currentHealth / maxHealth;
            Debug.Log("Decrease Fill");
            // Update the health bar image's fill amount
            healthBar.value = fillAmount;
            Debug.Log("2nd Decrease Fill");
        }



        private void Die()
        {
            // Perform actions when the cat's health reaches zero or below
            Debug.Log("Cat died!");
            // Add any necessary code, such as game over logic or respawning
        }
    }
}