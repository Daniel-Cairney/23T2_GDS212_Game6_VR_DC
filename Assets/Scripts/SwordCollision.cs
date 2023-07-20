using UnityEngine;
namespace DanielCairney
{
    public class SwordCollision : MonoBehaviour
    {
       // public AudioSource swordEffect;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                //swordEffect.Play();
                // Despawn the enemy after 1 second
                Destroy(other.gameObject, 1f);
            }
        }
    }
}