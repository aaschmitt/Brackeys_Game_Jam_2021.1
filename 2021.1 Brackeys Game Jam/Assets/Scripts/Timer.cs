using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /* Private Fields */
    private float _playedTime = 0f;
    private string _timeDisplay = null;
    private TextMeshProUGUI _textMeshProUGUI = null;
    [SerializeField] private TextMeshProUGUI finalTimerText = null;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        _playedTime += Time.deltaTime;
        _timeDisplay = _playedTime.ToString("0.00");
        UpdateDisplay();
    }
    
    /* Initialize any needed variables and get components */
    private void InitializeVariables()
    {
        _playedTime = 0;
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    
    /* Method to update the timer display */
    private void UpdateDisplay()
    {
        float minutes = Mathf.FloorToInt(_playedTime / 60);
        float seconds = Mathf.FloorToInt(_playedTime % 60);
        float milliseconds = _playedTime % 1 * 100;
        if (milliseconds >= 95) milliseconds = 0;
        _textMeshProUGUI.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void DisplayTime()
    {
        finalTimerText.text = _textMeshProUGUI.text;
    }
}
