using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorArrow : MonoBehaviour
{
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
