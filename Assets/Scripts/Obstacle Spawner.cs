using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 0.8f;
    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;
    [SerializeField] private float difficultyIncreaseRate = 0.1f;

    private float timeSinceLastSpawn;

    void Update()
    {
        
        transform.position = new Vector3(player.position.x + spawnDistance, transform.position.y, transform.position.z);
        
        timeSinceLastSpawn += Time.deltaTime;
        
        spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - difficultyIncreaseRate * Time.deltaTime);

        
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        AudioManager.instance.PlayFireballSFX();
    }
}