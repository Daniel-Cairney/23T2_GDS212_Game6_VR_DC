using UnityEngine;
namespace DanielCairney
{
    public class CatHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
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

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // Perform actions when the cat's health reaches zero or below
            Debug.Log("Cat died!");
            // Add any necessary code, such as game over logic or respawning
        }
    }
}