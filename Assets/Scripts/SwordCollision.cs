using UnityEngine;
namespace DanielCairney
{
    public class SwordCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                // Despawn the enemy after 1 second
                Destroy(other.gameObject, 1f);
            }
        }
    }
}