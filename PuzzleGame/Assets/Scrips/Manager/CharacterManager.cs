using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public GameObject Player;
    //public GameObject testPlayer;
    Controller CharacterController;

    //Powerup Booleans
    public bool DoubleJump = false;
    public bool CubeT2PowerUp = false;
    public bool CubeT3PowerUp = false;
    public bool Teleport = false;

    //Speech/Talking Booleans
    public bool Tier1PlateSpeech = false;
    public bool Tier2PlateSpeech = false;
    public bool Tier3PlateSpeech = false;
    public bool OnePlateSpeech = false;
    public bool TwoPlateSpeech = false;
    public bool ThreePlateSpeech = false;
    public bool FrozenBlockSpeech = false;

    AudioSource[] AllAudioSources;

    public AudioSource PlateT1;
    public AudioSource PlateT2;
    public AudioSource FrozenBlock;
    public AudioSource DoubleJumpPowerUp;
    public AudioSource LeverDeactivated;
    public AudioSource JumpingWithCube;
    // Use this for initialization
    void Start () {
        AllAudioSources = FindObjectsOfType<AudioSource>();

        CharacterController = Player.GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Tier1PlateSpeech == true && OnePlateSpeech == false)
        {
            stopAudio();
            PlateT1.Play();
            OnePlateSpeech = true;
        }

        if (Tier2PlateSpeech == true && TwoPlateSpeech == false)
        {
            stopAudio();
            PlateT2.Play();
            TwoPlateSpeech = true;
        }

        if(CharacterController.item == true && FrozenBlockSpeech == false)
        {
            if(CharacterController.CubeHit.collider.name == "FrozenCube")
            {
                stopAudio();
                FrozenBlock.Play();
                FrozenBlockSpeech = true;
            }
        }
    }

    public void stopAudio()
    {
        for (int i = 0; i < AllAudioSources.Length; i++)
        {
            AllAudioSources[i].Stop();
        }
    }
}
