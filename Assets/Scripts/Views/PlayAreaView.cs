using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaView : MonoBehaviour
{
    #region -----------------------Private Varialbes-------------------------
    [SerializeField] private SceneController sceneOneController;
    #endregion---------------------------------------------------------------

    #region -----------------------Public Varialbes--------------------------
    #endregion---------------------------------------------------------------

    #region -----------------------Private Methods---------------------------

    void Start()
    {
        Debug.Log("play area for game scene 1 now Active");
    }

    void Update()
    {

    }

    #endregion --------------------------------------------------------------

    #region -----------------------Public Varialbes--------------------------

    public void PlayerEntersPlayArea()
    {
        sceneOneController.PlayerEntersPlayArea();
    }

    public void PlayerExitsPlayArea()
    {
        sceneOneController.PlayerExitsPlayArea();
    }

    #endregion---------------------------------------------------------------
}
