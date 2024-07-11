using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    public static SongController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySong(AudioClip sound, float volume = 1.0f)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = volume; // Ajusta el volumen para este sonido específico
        audioSource.PlayOneShot(sound);
        Destroy(audioSource, sound.length);
    }
}
