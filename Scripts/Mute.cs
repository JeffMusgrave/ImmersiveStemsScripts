using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public GameObject leftChan;
    public GameObject rightChan;
    public bool muteFlip = false;

    private StemChannel stemChanL;
    private StemChannel stemChanR;
    private bool inMuteTrig = false;

    void Awake()
    {
        stemChanL = leftChan.GetComponent<StemChannel>();
        stemChanR = rightChan.GetComponent<StemChannel>();
    }

    void Update()
    {
        //listen for 'E' press
        if (inMuteTrig == true && Input.GetKeyDown(KeyCode.E))
        {
            //flip muteFlip status so that solo behaviour is reversed
            muteFlip = !muteFlip;

            //send mute signal to local stems
            stemChanL.MuteAudio();
            stemChanR.MuteAudio();
        }
    }


    //When near button, enable listen for 'E'
    private void OnTriggerEnter(Collider other)
    {
        inMuteTrig = true;
    }

    //When away from button, disable listen for 'E'
    private void OnTriggerExit(Collider other)
    {
        inMuteTrig = false;
    }
}
