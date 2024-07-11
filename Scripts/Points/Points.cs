using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esto si usas UI estándar de Unity
using TMPro; // Incluye esto si usas TextMeshPro

public class Points : MonoBehaviour
{
    public PointsController pointsController;
    public TextMeshProUGUI pointsText; // Cambia esto por public Text pointsText si usas UI estándar de Unity

    void Update()
    {
        if (pointsController != null && pointsText != null)
        {
            pointsText.text = "Puntos: " + pointsController.Points.ToString();
        }
    }
}