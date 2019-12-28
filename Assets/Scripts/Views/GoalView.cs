using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalView : MonoBehaviour {
    [SerializeField] private Renderer goalModelMat = null;
    [SerializeField] private SceneController sceneController = null;
    private bool scoreGoal = true;

    public void ItsAGoal () {
        if(scoreGoal)
        {   
            sceneController.PlayerScoredGoal();
            scoreGoal = false;
        }
    }
}