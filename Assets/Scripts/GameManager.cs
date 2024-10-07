using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void QuitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
            Application.Quit(); // Cierra el juego en una build
#endif

        Debug.Log("El juego se ha cerrado");
    }
}