using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [System.Serializable]
    public class SoundMapping
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1.0f;
    }

    [Header("Add Sounds")]
    [SerializeField] private List<SoundMapping> sounds = new List<SoundMapping>();

    private Dictionary<string, SoundMapping> soundDict = new Dictionary<string, SoundMapping>();

    private void Awake()
    {
        // Convertir la lista en un diccionario para un acceso más rápido
        foreach (SoundMapping mapping in sounds)
        {
            soundDict[mapping.name] = mapping;
        }
    }

    public void PlaySound(string name)
    {
        if (soundDict.TryGetValue(name, out SoundMapping sound))
        {
            SongController.Instance.PlaySong(sound.clip, sound.volume);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + name);
        }
    }

    /* Ejemplo de cómo podrías usar este script en colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlaySound("newLife"); // Asegúrate de tener un sonido con este nombre en la lista
        }
    }*/
}
