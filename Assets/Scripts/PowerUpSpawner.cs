using UnityEngine;

public class HealingItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healingItemPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f; 

    private float timeSinceLastSpawn;

    void Update()
    {
        
        timeSinceLastSpawn += Time.deltaTime;

        
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnHealingItem();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnHealingItem()
    {
        
        float randomY = Random.Range(minHeight, maxHeight);

        Vector3 spawnPosition = new Vector3(player.position.x + spawnDistance, randomY, 0);
        Instantiate(healingItemPrefab, spawnPosition, Quaternion.identity);
    }
}