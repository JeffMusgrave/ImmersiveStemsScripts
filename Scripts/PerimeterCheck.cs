using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerimeterCheck : MonoBehaviour
{
    private GameObject mastController;
    private StartStop startStop;

    void Awake()
    {
        mastController = GameObject.Find("StartStop");
        startStop = mastController.GetComponent<StartStop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(startStop.playState)
        {
            startStop.PlayStateFunc();
        } 
    }
}
