using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform background1;
    [SerializeField] private Transform background2;
    [SerializeField] private float repositionOffset = 1f;
    
    private float backgroundWidth; 
    private Transform cameraTransform; 
    

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
            Debug.LogError("No se encontró SpriteRenderer en el fondo 1.");
        }
    }

    void Update()
    {
        // Revisar si la cámara ha pasado al siguiente fondo (background2), ajustando el reposicionamiento con repositionOffset
        if (cameraTransform.position.x >= background2.position.x - repositionOffset)
        {
            // Reposicionar el fondo que quedó atrás adelante del otro
            background1.position = background2.position + new Vector3(backgroundWidth, 0, 0);

            // Intercambiar referencias para que el ciclo siga
            Transform temp = background1;
            background1 = background2;
            background2 = temp;
        }
    }
}