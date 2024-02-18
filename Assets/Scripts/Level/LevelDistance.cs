using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject endDisDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.45f;
    public int highestScore;
    public GameObject highScoreText;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0); 
        UpdateHighScoreUI();
    }


    public void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    private void UpdateHighScoreUI()
    {
        highScoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + highestScore.ToString();
    }
    public IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        endDisDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;

        if (disRun > highestScore)
        {
            highestScore = disRun;
            PlayerPrefs.SetInt("HighestScore", highestScore); 
            PlayerPrefs.Save();
            ChangeScoreColor();
            UpdateHighScoreUI();
        }

    }
    void ChangeScoreColor()
    {
        Color newColor = Color.yellow; 

        TextMeshProUGUI scoreText = disDisplay.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI highScoreTextUI = highScoreText.GetComponent<TextMeshProUGUI>();

        scoreText.color = newColor;
        highScoreTextUI.color = newColor;
    }

}
