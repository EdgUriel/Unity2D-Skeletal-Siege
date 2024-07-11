using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPoint : MonoBehaviour
{
    //[SerializeField] private GameObject efecto;
    [SerializeField] private float energyValue;

    public float rotationSpeed = 180f;  // Velocidad de rotación en grados por segundo
    public float levitationAmplitude = 0.5f; // Amplitud del movimiento de levitación
    public float levitationFrequency = 2f; // Frecuencia del movimiento de levitación
    

    private Vector3 startPosition;

    
    private void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial para usar como base del movimiento de levitación
    }

    private void Update() 
    {
        // Rotación en el eje Z
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        // Movimiento de levitación
        float levitation = Mathf.Sin(Time.time * levitationFrequency) * levitationAmplitude;
        transform.position = startPosition + new Vector3(0, levitation, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PointsController.Instance.AddPoints(energyValue);
            //Instantiate(efecto, transform.position, Quaternion.identity);
            //SongController.Instance.PlaySong(efecto, 1.0f); // Asume que SongController está configurado correctamente
            Destroy(gameObject);
        }
    }
}