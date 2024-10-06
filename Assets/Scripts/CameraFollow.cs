using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Vector3 offset; // Offset para ajustar la posición de la cámara

    void Update()
    {
        // Actualizar la posición de la cámara para seguir al jugador en el eje X
        transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z);
    }
}