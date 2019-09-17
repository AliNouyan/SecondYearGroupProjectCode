using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRaiseWall : MonoBehaviour {

    public GameObject Platform;

    PlatformController PlatformScript;
    Animator WallAnim;

    public bool WallRaised;
    public bool StartRaised;

    // Use this for initialization
    void Start () {
        PlatformScript = Platform.GetComponent<PlatformController>();
        WallAnim = this.GetComponent<Animator>();

        if(StartRaised == false)
        {
            WallAnim.SetBool("LowerWall", true);
        }
        else
        {
            WallAnim.SetBool("RaiseWall", true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(StartRaised == false)
        {
            if (PlatformScript.PlatActivate == true)
            {
                if (WallRaised == false)
                {
                    StartCoroutine(RaiseWall());
                }
            }
            else
            {
                if (WallRaised == true)
                { 
                    StartCoroutine(LowerWall());
                }
            }
        }

        if(StartRaised == true)
        {
            if (PlatformScript.PlatActivate == true)
            {
                if (WallRaised == true)
                {
                    StartCoroutine(LowerWall());
                }
            }
            else
            {
                if (WallRaised == false)
                {
                    StartCoroutine(RaiseWall());
                }
            }
        }
    }

    IEnumerator RaiseWall()
    {
        WallRaised = true;
        WallAnim.SetBool("RaiseWall", true);
        WallAnim.SetBool("LowerWall", false);
        yield return null;
    }

    IEnumerator LowerWall()
    {
        WallRaised = false;
        WallAnim.SetBool("RaiseWall", false);
        WallAnim.SetBool("LowerWall", true);
        yield return null;
    }
}
