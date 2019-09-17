using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour {

    public bool RoomBool;

	// Use this for initialization
	void Start () {
        RoomBool = true;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(RoomBool);
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            RoomBool = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            RoomBool = false;
        }
    }
}
