using System.Collections;
using UnityEngine;
namespace DanielCairney
{



    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Transform spawnZone;
        public float initialSpawnDelay = 1f;
        public float spawnCooldown = 10f;

        private int spawnCount = 1;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            yield return new WaitForSeconds(initialSpawnDelay);

            while (true)
            {
                for (int i = 0; i < spawnCount; i++)
                {
                    SpawnEnemy();
                }

                spawnCount++;
                yield return new WaitForSeconds(spawnCooldown);
            }
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector3 zoneSize = spawnZone.localScale;
            Vector3 randomOffset = new Vector3(
                Random.Range(-zoneSize.x / 2f, zoneSize.x / 2f),
                Random.Range(-zoneSize.y / 2f, zoneSize.y / 2f),
                Random.Range(-zoneSize.z / 2f, zoneSize.z / 2f)
            );

            Vector3 spawnPosition = spawnZone.position + randomOffset;
            return spawnPosition;
        }
    }

}