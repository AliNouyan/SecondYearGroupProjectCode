using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour {

    
    Animator DoorAnim; //gets animations from object

    public bool DoorOpened = false; //begin closed

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (DoorOpened == true) //when inside collider opens door with animation
        {
            DoorAnim = this.GetComponent<Animator>();
            DoorAnim.SetBool("DoorOpen", true);
            DoorAnim.SetBool("DoorClose", false);
        }
        else
        {
            DoorAnim = this.GetComponent<Animator>(); //when left collider, door shuts with animation
            DoorAnim.SetBool("DoorOpen", false);
            DoorAnim.SetBool("DoorClose", true);
        }

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            DoorOpened = true;

        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            DoorOpened = false;

        }
    }
}
