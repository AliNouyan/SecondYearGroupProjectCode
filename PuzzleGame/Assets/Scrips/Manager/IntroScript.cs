using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour {

    public GameObject Door;
    public GameObject RoomTrigger;
    public GameObject GlassPod;

    GameObject Player;
    Controller playerController;
    Animator DoorAnim;

    float WaitTime = 12f;
    float DoorWaitTime = 25f;
    bool roomCheck;

    public AudioSource IntroRoomOne;
    public AudioSource IntroRoomTwo;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<Controller>();
        GlassPod.GetComponent<MeshCollider>().isTrigger = true;
        playerController.enabled = false;
        StartCoroutine(FreezePlayer());

        //Play Soft Music
        //Play Audio(AM talking)
        IntroRoomOne.Play();
        Debug.Log("Audio 1");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(RoomCheck);
	}

    IEnumerator FreezePlayer()
    {
        //WaitTime == the ammount of time for AM to tell you to step out of the pod
        yield return new WaitForSeconds(WaitTime);
        playerController.enabled = true;
    }

    private void OnTriggerExit(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            GlassPod.GetComponent<MeshCollider>().isTrigger = false;
            this.GetComponent<BoxCollider>().enabled = false;

            //Play Audio2(AM talking)
            Debug.Log("Audio 2");
            IntroRoomTwo.Play();

            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        //DoorWaitTime == the ammount of time for AM to open the first door
        yield return new WaitForSeconds(DoorWaitTime);

        DoorAnim = Door.GetComponent<Animator>();
        DoorAnim.SetBool("DoorOpen", true);
        DoorAnim.SetBool("DoorClose", false);

        //StartCoroutine(Extras());
    }

    IEnumerator Extras()
    {
        yield return new WaitForSeconds(1f);

        roomCheck = RoomTrigger.GetComponent<RoomCheck>().RoomBool;
        if(roomCheck == true)
        {
            //Play Audio(Something like "Are you still in this room? Proceed with the test.")
            Debug.Log("Warning 1");

            yield return new WaitForSeconds(1f);

            roomCheck = RoomTrigger.GetComponent<RoomCheck>().RoomBool;
            if (roomCheck == true)
            {
                //Play Audio(Something like "You will be terminated if you dont leave the room in 10 seconds.")
                Debug.Log("Warning 2");

                yield return new WaitForSeconds(1f);

                roomCheck = RoomTrigger.GetComponent<RoomCheck>().RoomBool;
                if (roomCheck == true)
                {
                    //Kill Player
                    Debug.Log("You are dead");
                }
            }
        }
    }
}
