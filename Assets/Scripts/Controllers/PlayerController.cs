using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region -----------------------Private Varialbes-------------------------

    #endregion---------------------------------------------------------------

    #region -----------------------Public Varialbes--------------------------
    #endregion---------------------------------------------------------------

    #region -----------------------Private Methods---------------------------

    void Start()
    {
        Debug.Log("player now Active");
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Player Collided with :" + Other.name);

        if (Other.tag == "PlayArea")
        {
            Other.GetComponent<PlayAreaView>().PlayerEntersPlayArea();
        }
    }

    void OnTriggerExit(Collider Other)
    {
        Debug.Log("Player exits with :" + Other.name);

        if (Other.tag == "PlayArea")
        {
            Other.GetComponent<PlayAreaView>().PlayerExitsPlayArea();
        }
    }

    #endregion -----------------------------------------------------------------
}
