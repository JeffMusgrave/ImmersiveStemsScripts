using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemChannel : MonoBehaviour
{
    public GameObject soloObj;
    public bool muteState = false;
    public GameObject muteObj;

    private Solo soloFunc;
    private AudioSource audioSource;
    private Mute muteController;
    private readonly float muteVolume = 0.0f;
    private readonly float unMuteVolume = 1.0f;

    void Awake()
    {
        audioSource     = GetComponent<AudioSource>();
        soloFunc        = soloObj.GetComponent<Solo>();
        muteController  = muteObj.GetComponent<Mute>();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    //Check to see if track is playing. StartStop calls via Update()
    public bool CheckPlay() {
        return audioSource.time >= audioSource.clip.length; 
    }

    //revisit... maybe easier way of doing this
    //controls normal mute/unmute function, as well as solo via muting everything else
    //also enables unmute for solo on a muted track, which will re-mute upon leaving solo mode.
    public void MuteAudio()
    {
        //if solo isn't engaged
        if (!soloFunc.ignoreMute)
        {
            //if mute button was pressed or stepping off solo'd stem, 
            //MUTE / REMUTE
            if (!muteState || (muteState && muteController.muteFlip))
            {
                muteState = true;
                audioSource.volume = muteVolume;
            }
            //UNMUTE
            else if (muteState)
            {
                muteState = false;
                audioSource.volume = unMuteVolume;
            }
        }

        //if solo is engaged
        else
        {
            //UNMUTE
            if (muteState && muteController.muteFlip)
            {
                muteState = false;
                audioSource.volume = unMuteVolume;
            }
        }


    }

}
