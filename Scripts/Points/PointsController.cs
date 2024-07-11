using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointsController : MonoBehaviour
{
    public static PointsController Instance;
    [SerializeField] private float points = 0;
  
    private void Awake()
    {
        if (PointsController.Instance == null)
        {
            PointsController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(float _value)
    {
        points += _value;
    }

    public float Points
    {
        get { return points; }
    }
}
