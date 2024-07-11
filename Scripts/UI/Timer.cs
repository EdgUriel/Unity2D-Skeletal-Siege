//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{  

    [Header ("Text Settings")]
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    bool isPaused = false; 

    void Update()
    {
        if(!isPaused) {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void PauseTimer() {
        isPaused = true; 
    }

    public void ResumeTimer() {
        isPaused = false; 
    }


}
