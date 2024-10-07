using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource movementSource;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource damageSource;
    [SerializeField] private AudioSource deathSource;
    [SerializeField] private AudioSource fireballSource;

    private AudioSource[] audioSources;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSources = new AudioSource[] { musicSource, movementSource, jumpSource, damageSource, deathSource, fireballSource };
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
  
    public void PlayMovementSFX()
    {
        movementSource.Play();
    }

    public void StopMovementSFX()
    {
        movementSource.Stop();
    }
   
    public void PlayJumpSFX()
    {
        jumpSource.Play();
    }

    public void StopJumpSFX()
    {
        jumpSource.Stop();
    }
  
    public void PlayDamageSFX()
    {
        damageSource.Play();
    }

    public void StopDamageSFX()
    {
        damageSource.Stop();
    }
  
    public void PlayDeathSFX()
    {
        deathSource.Play();
    }

    public void StopDeathSFX()
    {
        deathSource.Stop();
    }
    
    public void PlayFireballSFX()
    {
        fireballSource.Play();
    }

    public void StopFireballSFX()
    {
        fireballSource.Stop();
    }
   
    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0f, 1f);
        Debug.Log("Volumen ajustado a: " + volume);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }

}