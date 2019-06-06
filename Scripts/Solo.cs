using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo : MonoBehaviour
{
    public GameObject leftChan;
    public GameObject rightChan;

    private StemChannel stemChanL;
    private StemChannel stemChanR;
    private GameObject mastController;
    private StartStop startStop;

    public bool ignoreMute = false;

    void Awake()
    {
        mastController  = GameObject.Find("StartStop");
        startStop       = mastController.GetComponent<StartStop>();
        stemChanL       = leftChan.GetComponent<StemChannel>();
        stemChanR       = rightChan.GetComponent<StemChannel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //local ignore mute that SoloBroadcast() will send out
        ignoreMute = true;

        //broadcast MUTE to all other tracks.
        startStop.SoloBroadcast();
        stemChanL.muteState = true;
        stemChanR.muteState = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //disable local ignore.
        ignoreMute = false;

        //broadcast mute message again to UNMUTE
        startStop.SoloBroadcast();
    }
}
