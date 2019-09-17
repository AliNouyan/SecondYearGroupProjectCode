using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject Platform;

    PlatformController PlatformScript;
    Animator DoorAnim;

    public bool DoorOpened = false; 

    // Use this for initialization
    void Start () {
        PlatformScript = Platform.GetComponent<PlatformController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlatformScript.PlatActivate == true)
        {
            if(DoorOpened == false)
            {
                StartCoroutine(DoorOpen());
            }
        }
        else
        {
            if(DoorOpened == true)
            {
                StartCoroutine(DoorClose());
            }
        }
	}

    IEnumerator DoorOpen()
    {
        DoorOpened = true;
        DoorAnim = this.GetComponent<Animator>();
        DoorAnim.SetBool("DoorOpen", true);
        DoorAnim.SetBool("DoorClose", false);
        yield return null;
    }

    IEnumerator DoorClose()
    {
        DoorOpened = false;
        DoorAnim = this.GetComponent<Animator>();
        DoorAnim.SetBool("DoorOpen", false);
        DoorAnim.SetBool("DoorClose", true);
        yield return null;
    }
}
