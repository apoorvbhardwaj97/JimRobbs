using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalView : MonoBehaviour {
    [SerializeField] private Renderer goalModelMat = null;
    [SerializeField] private Material itsGoalMat;
    public void ItsAGoal () {
        goalModelMat.material = itsGoalMat;
    }
}