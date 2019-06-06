using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{

    public float ambVol = 0.9f;
    private GameObject mastController;
    private StartStop startStop;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        mastController = GameObject.Find("StartStop");
        startStop = mastController.GetComponent<StartStop>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = ambVol;
    }

    public void PlayAmb()
    {
        audioSource.Play();
    }
    public void StopAmb()
    {
        audioSource.Stop();
    }
}
