using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("ball for Game Scene 1 now Active");
    }

    void Update()
    {

    }

    private void GetMouseInput()
    {
        Vector3 startPos, endPos;
        float startTime, EndTime;
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            EndTime = Time.time;
        }
    }

}
