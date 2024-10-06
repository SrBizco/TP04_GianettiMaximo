using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // El prefab del obstáculo o plataforma
    public Transform player; // Referencia al transform del jugador
    public float spawnInterval = 2f; // Tiempo entre cada generación
    public float spawnDistance = 10f; // Distancia por delante del jugador para generar obstáculos
    public float minHeight = -1f; // Altura mínima de generación
    public float maxHeight = 2f; // Altura máxima de generación
    private float timeSinceLastSpawn;

    void Update()
    {
        // Mover el spawner junto con el jugador, a una distancia fija por delante
        transform.position = new Vector3(player.position.x + spawnDistance, transform.position.y, transform.position.z);

        // Incrementar el tiempo desde la última generación
        timeSinceLastSpawn += Time.deltaTime;

        // Si el tiempo desde la última generación supera el intervalo, genera un nuevo obstáculo
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f; // Reiniciar el contador de tiempo
        }
    }

    void SpawnObstacle()
    {
        // Determinar una posición aleatoria en el eje Y (altura)
        float randomY = Random.Range(minHeight, maxHeight);

        // Crear el obstáculo en una posición nueva
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}