using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneOneController : MonoBehaviour
{
    #region -----------------------Private Varialbes-------------------------
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject playAreaGO;

    #endregion---------------------------------------------------------------

    #region -----------------------Public Varialbes--------------------------
    #endregion---------------------------------------------------------------

    #region -----------------------Private Methods---------------------------

    void Start()
    {
        Debug.Log("Game Scene 1 now Active");
    }

    void Update()
    {

    }

    private void SpawnBallPrefab()
    {
        Instantiate(ballPrefab);
    }

    public void PlayerEntersPlayArea()
    {
        Debug.Log("Player Enters Play Area");
        playAreaGO.GetComponent<Material>().color = Color.red;
        SpawnBallPrefab();
    }

    public void PlayerExitsPlayArea()
    {
        Debug.Log("Player Enters Play Area");
        playAreaGO.GetComponent<Material>().color = Color.blue;
    }

    #endregion -----------------------------------------------------------------
}
