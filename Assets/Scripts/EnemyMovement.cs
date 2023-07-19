using UnityEngine;

namespace DanielCairney
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private GameObject catTarget;

        private void Start()
        {
            // Find the GameObject with the "Cat" tag
            catTarget = GameObject.FindGameObjectWithTag("Cat");
        }

        private void Update()
        {
            if (catTarget != null)
            {
                // Calculate the direction to the cat
                Vector3 direction = (catTarget.transform.position - transform.position).normalized;

                // Calculate the desired movement for this frame
                Vector3 movement = direction * moveSpeed * Time.deltaTime;

                // Apply the movement to the enemy's position
                transform.Translate(movement, Space.World);
            }
        }
    }
}
