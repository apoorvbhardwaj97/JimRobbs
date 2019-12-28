using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.HelloAR;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private List<SceneController> gameStageScenes = null;
    [SerializeField] private GameObject infoText = null;
    [SerializeField] private float sceneChangeDelay = 5f;
    private GameController gameController = null;
    private UIController uIController = null;
    private SceneController currentGameScene = null;
    private int ballsUsed = 0, goalsScored;
    private int currentGameStage = 0;

    void Start()
    {
        ChangeStage(0);
    }


    private void ChangeStage(int gameStage)
    {
        if (gameStage < gameStageScenes.Count)
        {
            currentGameScene = gameStageScenes[gameStage];
            currentGameScene.ToggleScene(true);
        }
        else
        {
            infoText.SetActive(true);
            ShowUITutorial(3);
        }
    }

    public void IncrementScore()
    {
        goalsScored++;
        uIController.UpdateUI(goalsScored, ballsUsed);
    }

    public void IncrementBallsUsed()
    {
        ballsUsed++;
        uIController.UpdateUI(goalsScored, ballsUsed);
    }

    public void ShowUITutorial(int tutNum)
    {
        uIController.ShowUITutorial(tutNum);
    }

    public void SetRefrences(UIController uI, GameController gC)
    {
        gameController = gC;
        uIController = uI;
        ShowUITutorial(1);
    }

    public void IncrementStage()
    {
        StartCoroutine(IncrementStageCoroutine());
    }

    private IEnumerator IncrementStageCoroutine()
    {
        yield return new WaitForSeconds(sceneChangeDelay);
        DestroyCurrentScene();
        ChangeStage(++currentGameStage);
    }

    private void DestroyCurrentScene()
    {
        currentGameScene.DestroyBallPrefab();
        currentGameScene.ToggleScene(false);
        currentGameScene = null;
    }

}
