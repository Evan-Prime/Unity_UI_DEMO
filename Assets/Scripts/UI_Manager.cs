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
    private bool toggledOff = true;
    [SerializeField] private GameObject toggleImage;
    [SerializeField] private GameObject toggleShowText;
    [SerializeField] private GameObject toggleHideText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private InputField userInput;
    [SerializeField] private TMP_Text slimeNameText;

    private void Awake()
    {
        scoreText.text = "Score: " + startingValue;
        ImageToggle();
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

    public void ScoreRandom()
    {
        int randomValue;
        randomValue = Random.Range(maxValue, resetValue);

        ScoreUpdate(randomValue);
    }

    public void ImageToggle()
    {
        if(toggledOff == true)
        {
            toggleImage.SetActive(true);
            toggleHideText.SetActive(true);
            toggleShowText.SetActive(false);
            toggledOff = false;
        }
        else if (toggledOff == false)
        {
            toggleImage.SetActive(false);
            toggleHideText.SetActive(false);
            toggleShowText.SetActive(true);
            toggledOff = true;
        }
        

    }

    private void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Return))
        {
            slimeNameText.text = userInput.text;
            userInput = null;
        }
    }

    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
