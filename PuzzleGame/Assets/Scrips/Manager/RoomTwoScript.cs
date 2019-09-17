using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoScript : MonoBehaviour {

    public AudioSource WalkIntoFirstRoom;
    AudioSource[] AllAudioSources;
    bool audioPlayed = false;

	// Use this for initialization
	void Start () {
        AllAudioSources = FindObjectsOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (audioPlayed == false)
            {
                for(int i = 0; i < AllAudioSources.Length; i++)
                {
                    AllAudioSources[i].Stop();
                }

                WalkIntoFirstRoom = this.GetComponent<AudioSource>();
                WalkIntoFirstRoom.Play();
                audioPlayed = true;
            }
        }
    }
}
