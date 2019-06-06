using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    public bool playState = false;
    public bool soloState = false;
    private StemChannel[] stemChan;

    void Awake()
    {
        stemChan = GetComponentsInChildren<StemChannel>();
    }

    void Update()
    {
        if (stemChan[0].CheckPlay() == true)
        {
            playState = false;
        } 
    }

    //Start/Stop button behaviour
    private void OnTriggerEnter(Collider other)
    {
        PlayStateFunc();
    }

    public void PlayStateFunc() {
        //Game starts playState at FALSE
        //if false, set true and then... 
        //PLAY AUDIO
        if (!playState)
        {
            playState = true;
            for (int i = 0; i < stemChan.Length; i++)
            {
                stemChan[i].PlayAudio();
            }
        }

        //if stepping on button again after playing
        //STOP AUDIO
        else
        {
            playState = false;
            for (int i = 0; i < stemChan.Length; i++)
            {
                stemChan[i].StopAudio();
            }
        }
    }

    //SOLO via MUTING all other stems
    public void SoloBroadcast()
    {
        for (int i = 0; i < stemChan.Length; i++)
        {
            stemChan[i].MuteAudio();
        }
    }
}
