using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text ballCount = null;
    void Start () {
        scoreText.text = "0";
        ballCount.text = "0";
    }

    void UpdateUI (int score, int ballUsed) {
        scoreText.text = (score).ToString();
        ballCount.text = (ballUsed).ToString();

    }
}