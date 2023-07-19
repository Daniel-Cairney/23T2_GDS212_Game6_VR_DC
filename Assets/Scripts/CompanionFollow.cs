using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DanielCairney
{
    public class CompanionFollow : MonoBehaviour
    {
        public Transform playerTransform;
        public float distance = 5f;
        public float moveSpeed = 2f;

        // Update is called once per frame
        void Update()
        {
            Vector3 targetPosition = playerTransform.position + playerTransform.forward * distance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);   
        }
    }
}
