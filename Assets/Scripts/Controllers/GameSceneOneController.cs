using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneOneController : MonoBehaviour {
#region -----------------------Private Varialbes-------------------------
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject playAreaGO;
    [SerializeField] private Material platformInsideMat;
    [SerializeField] private Material platformOutsideMat;
    private GameObject spawnedBall = null;
    private bool playerInside = false;
    private int ballsUsed = 0;
    private int score = 0;
    private BallController spawnedBallController = null;

#endregion---------------------------------------------------------------

#region -----------------------Public Varialbes--------------------------
#endregion---------------------------------------------------------------

#region -----------------------Private Methods---------------------------

    void Start () {
        Debug.Log ("Game Scene 1 now Active");
    }

    void Update () {

    }

    private void SpawnBallPrefab () {
        spawnedBall = Instantiate (ballPrefab, Camera.main.transform.GetChild (0));
        spawnedBallController = spawnedBall.GetComponent<BallController> ();
        spawnedBallController.SetSceneOneController (this);
    }

    private void DestroyBallPrefab () {
        Destroy (spawnedBall);
    }

    public void RespawnBall () {
        if (playerInside) {
            DestroyBallPrefab ();
            SpawnBallPrefab ();
        }
    }
    public void PlayerEntersPlayArea () {
        playerInside = true;
        Debug.Log ("Player Enters Play Area");
        playAreaGO.GetComponent<Renderer> ().material = platformInsideMat;
        SpawnBallPrefab ();
    }

    public void PlayerExitsPlayArea () {
        playerInside = false;
        Debug.Log ("Player Enters Play Area");
        playAreaGO.GetComponent<Renderer> ().material = platformOutsideMat;
        DestroyBallPrefab ();
    }

    public void ChangeBallParentToScene () {
        Debug.Log ("Ball parent changed to scene");
        spawnedBall.transform.SetParent (this.transform);
    }

#endregion -----------------------------------------------------------------

}