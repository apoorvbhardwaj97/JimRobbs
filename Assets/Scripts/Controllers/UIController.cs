using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text ballCount = null;
    [SerializeField] private Text tutorialText = null;
    [Header("Tutorial strings")]
    [SerializeField] private List<string> tutorialStrings = null;

    void Start()
    {
        ShowUITutorial(0);
    }

    public void UpdateUI(int score, int ballUsed)
    {
        scoreText.text = (score).ToString();
        ballCount.text = (ballUsed).ToString();
    }

    public void ShowUITutorial(int tutorialNum)
    {
        tutorialText.text = tutorialStrings[tutorialNum];
    }
}