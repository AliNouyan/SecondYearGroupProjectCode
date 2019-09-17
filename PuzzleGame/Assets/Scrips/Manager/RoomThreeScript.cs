using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThreeScript : MonoBehaviour {

    public AudioSource ThrowCube;
    public AudioSource LeverDescription;
    AudioSource[] AllAudioSources;
    bool audioPlayed = false;
    bool audioTwoPlayed = false;
    bool WalkIn = false;
    bool WalkOut = false;

    // Use this for initialization
    void Start()
    {
        AllAudioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider player)
    {
        if(WalkIn == false)
        {
            if (player.gameObject.tag == "Player")
            {
                if (audioPlayed == false)
                {
                    for (int i = 0; i < AllAudioSources.Length; i++)
                    {
                        AllAudioSources[i].Stop();
                    }

                    ThrowCube = this.GetComponent<AudioSource>();
                    ThrowCube.Play();
                    audioPlayed = true;
                    WalkIn = true;
                }
            }
        }
        else if (WalkIn == true && WalkOut == false)
        {
            if (player.gameObject.tag == "Player")
            {
                if (audioTwoPlayed == false)
                {
                    for (int i = 0; i < AllAudioSources.Length; i++)
                    {
                        AllAudioSources[i].Stop();
                    }

                    LeverDescription.Play();
                    audioPlayed = true;
                    WalkIn = true;
                }
            }
        }
    }
}