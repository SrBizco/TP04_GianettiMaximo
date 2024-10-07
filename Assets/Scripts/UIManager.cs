using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private Slider volumeSlider;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);

        
        float initialVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = initialVolume; 
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
        AudioManager.instance.PlayMusic();
        AudioManager.instance.PlayMovementSFX();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
        AudioManager.instance.StopMusic();
        AudioManager.instance.StopMovementSFX();   
    }

    private void OpenOptions()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    private void BackToPauseMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume); 
       
    }
}