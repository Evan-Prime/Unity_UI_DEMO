using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    private int value = 0;
    private int startingValue = 0;
    private int resetValue = -999999999;
    private int maxValue = 999999999;
    private int minValue = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        scoreText.text = "Score: " + startingValue;
    }

    public void ScoreUpdate(int newValue)
    {
        if (newValue == resetValue)
        {
            value = minValue;
        }
        else
        {
            value += newValue;
        }

        if (value > maxValue)
        {
            value = maxValue;
        }
        else if (value < minValue) 
        { 
            value = minValue;
        }

        scoreText.text = "Score: " + value;
    }

    private void Update()
    {
        scoreText.text = "Score: " + value;
    }

    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
