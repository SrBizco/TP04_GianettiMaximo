using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform background1; // Primer fondo (padre vac�o)
    public Transform background2; // Segundo fondo (padre vac�o)

    private float backgroundWidth; // Ancho del fondo
    private Transform cameraTransform; // Transform de la c�mara
    public float repositionOffset = 1f; // Ajuste para que se reposicione antes

    void Start()
    {
        cameraTransform = Camera.main.transform;

        // Obtener el Sprite Renderer de los hijos del primer fondo para obtener el ancho
        SpriteRenderer sr = background1.GetComponentInChildren<SpriteRenderer>();

        if (sr != null)
        {
            backgroundWidth = sr.bounds.size.x; // Ancho del fondo (de un hijo)
        }
        else
        {
            Debug.LogError("No se encontr� SpriteRenderer en el fondo 1.");
        }
    }

    void Update()
    {
        // Revisar si la c�mara ha pasado al siguiente fondo (background2), ajustando el reposicionamiento con repositionOffset
        if (cameraTransform.position.x >= background2.position.x - repositionOffset)
        {
            // Reposicionar el fondo que qued� atr�s adelante del otro
            background1.position = background2.position + new Vector3(backgroundWidth, 0, 0);

            // Intercambiar referencias para que el ciclo siga
            Transform temp = background1;
            background1 = background2;
            background2 = temp;
        }
    }
}