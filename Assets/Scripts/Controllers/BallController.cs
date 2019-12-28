using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallController : MonoBehaviour
{
    private SceneController sceneController;
    [SerializeField] private float xForceMultiplier;
    [SerializeField] private float yForceMultiplier;
    [SerializeField] private int ballRespawnTime;
    [SerializeField] private float maxFwForce;
    [SerializeField] private float maxUpForce;
    [SerializeField] private GameObject goalParticles = null;
    private bool takeInput = true;
    private float touchStartTime = 0, touchEndTime = 0;
    private Vector3 startPos, endPos;

    private Rigidbody ballRb;

    public void SetSceneOneController(SceneController sc)
    {
        sceneController = sc;
    }

    void Start()
    {
        Debug.Log("ball for Game Scene 1 now Active");
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time - touchEndTime > ballRespawnTime && touchEndTime > 0.1f)
        {
            sceneController.RespawnBall();
        }
    }

    void FixedUpdate()
    {
        if (takeInput)
        {
            GetMouseInput();
        }
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            Debug.Log("<color=green>Mouse Touch started : </color>" + startPos);
            touchStartTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            Debug.Log("<color=red>Mouse Touch Ended : </color>" + endPos);
            touchEndTime = Time.time;
            ThrowBall(xForceMultiplier * (endPos.y - startPos.y) * 0.005f, yForceMultiplier * (touchEndTime - touchStartTime) * 10);
            //time diffrence is used for vertical force , touch is used for horizontal force
        }
    }

    private void ThrowBall(float fwForce, float upForce)
    {
        fwForce = fwForce > maxFwForce ? maxFwForce : fwForce;
        upForce = upForce > maxUpForce ? maxUpForce : upForce;
        Debug.Log("<color=blue>Throwing with force </color>" + (fwForce) + " , " + upForce);
        ballRb.AddRelativeForce(0, upForce, fwForce, ForceMode.Impulse);
        ballRb.useGravity = true;
        sceneController.ChangeBallParentToScene();
        takeInput = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            other.GetComponent<GoalView>().ItsAGoal();
            Instantiate(goalParticles, sceneController.transform);
            
        }
    }

}