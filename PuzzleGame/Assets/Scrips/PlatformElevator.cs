using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformElevator : MonoBehaviour {

    public float speed = 1.0f;

    Animator LiftAnim;
    public GameObject Platform;
    PlatformController PlatformScript;

    public bool LiftMove = false;

    // Use this for initialization
    void Start () {
        PlatformScript = Platform.GetComponent<PlatformController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlatformScript.PlatActivate == true)
        {
            //LiftMove = true;
            LiftAnim = this.GetComponent<Animator>();
            LiftAnim.SetBool("PlatformSet", true);
        }

        else if (LiftMove == true) 
        {
            LiftAnim = this.GetComponent<Animator>();
            LiftAnim.SetBool("Up", true);
            LiftAnim.SetBool("Down", false);

        }
        else
        {
            LiftAnim = this.GetComponent<Animator>();
            LiftAnim.SetBool("Up", false);
            LiftAnim.SetBool("Down", true);
        }

        // this.transform.Translate(Vector3.forward * Time.deltaTime / speed);

        // this.transform.Translate(Vector3.back * Time.deltaTime / speed);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            LiftMove = true;

        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            LiftMove = false;

        }
    }


}
