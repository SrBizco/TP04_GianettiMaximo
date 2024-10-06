using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Vector3 offset; // Offset para ajustar la posici�n de la c�mara

    void Update()
    {
        // Actualizar la posici�n de la c�mara para seguir al jugador en el eje X
        transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z);
    }
}