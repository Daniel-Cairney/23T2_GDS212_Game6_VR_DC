using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
                CatDie();
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



        private void CatDie()
        {
            SceneManager.LoadScene("Game Over Scene");
        }
    }
}