using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource movementSource;
    public AudioSource jumpSource;
    public AudioSource damageSource;
    public AudioSource deathSource;
    public AudioSource fireballSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene el AudioManager al cambiar de escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Funciones para reproducir y detener la música
    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Funciones para reproducir y detener el sonido de movimiento
    public void PlayMovementSFX()
    {
        movementSource.Play();
    }

    public void StopMovementSFX()
    {
        movementSource.Stop();
    }

    // Funciones para reproducir y detener el sonido de salto
    public void PlayJumpSFX()
    {
        jumpSource.Play();
    }

    public void StopJumpSFX()
    {
        jumpSource.Stop();
    }

    // Funciones para reproducir y detener el sonido de recibir daño
    public void PlayDamageSFX()
    {
        damageSource.Play();
    }

    public void StopDamageSFX()
    {
        damageSource.Stop();
    }

    // Funciones para reproducir y detener el sonido de muerte
    public void PlayDeathSFX()
    {
        deathSource.Play();
    }

    public void StopDeathSFX()
    {
        deathSource.Stop();
    }

    // Funciones para reproducir y detener el sonido de bola de fuego
    public void PlayFireballSFX()
    {
        fireballSource.Play();
    }

    public void StopFireballSFX()
    {
        fireballSource.Stop();
    }
}