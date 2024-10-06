using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // El prefab del obst�culo o plataforma
    public Transform player; // Referencia al transform del jugador
    public float spawnInterval = 2f; // Tiempo entre cada generaci�n
    public float spawnDistance = 10f; // Distancia por delante del jugador para generar obst�culos
    public float minHeight = -1f; // Altura m�nima de generaci�n
    public float maxHeight = 2f; // Altura m�xima de generaci�n
    private float timeSinceLastSpawn;

    void Update()
    {
        // Mover el spawner junto con el jugador, a una distancia fija por delante
        transform.position = new Vector3(player.position.x + spawnDistance, transform.position.y, transform.position.z);

        // Incrementar el tiempo desde la �ltima generaci�n
        timeSinceLastSpawn += Time.deltaTime;

        // Si el tiempo desde la �ltima generaci�n supera el intervalo, genera un nuevo obst�culo
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f; // Reiniciar el contador de tiempo
        }
    }

    void SpawnObstacle()
    {
        // Determinar una posici�n aleatoria en el eje Y (altura)
        float randomY = Random.Range(minHeight, maxHeight);

        // Crear el obst�culo en una posici�n nueva
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}