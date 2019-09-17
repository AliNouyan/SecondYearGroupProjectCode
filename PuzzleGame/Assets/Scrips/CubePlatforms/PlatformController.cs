using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    GameObject cube;
    Cube CubeScript;
    Animator anim;
    CharacterManager characterManager;

    public bool PlatActivate = false;
    public int platWeight;
    public int cubeWeight;

    bool PlayerPlat = false;
    bool CubeBool = false;
    // Use this for initialization
    void Start () {
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        characterManager = GameController.GetComponent<CharacterManager>();

        anim = this.GetComponent<Animator>();

        if (this.gameObject.tag == "PlatTier1")
        {
            platWeight = 100;
        }

        if (this.gameObject.tag == "PlatTier2")
        {
            platWeight = 150;
        }

        if (this.gameObject.tag == "PlatTier3")
        {
            platWeight = 250;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(CubeBool == true)
        {
            cubeWeight = CubeScript.CombinedWeight;
        }

        if (PlayerPlat == false)
        {
            if (cubeWeight >= platWeight)
            {
                StartCoroutine(buttonDown());

                
            }
            else if (cubeWeight < platWeight)
            {
                StartCoroutine(buttonUp());
            }
        }
    }

    public void OnTriggerEnter(Collider cube)
    {
        if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3")
        {
            CubeScript = cube.gameObject.GetComponent<Cube>();
            CubeBool = true;
        }

        else if (this.gameObject.tag == "PlatTier1")
        {
            if (cube.gameObject.tag == "Player")
            {
                //Debug.Log("Hello");
                PlayerPlat = true;
                StartCoroutine(buttonDown());
            }
        }

        else if ((this.gameObject.tag == "PlatTier2") && (characterManager.CubeT2PowerUp == true))
        {
            if (cube.gameObject.tag == "Player")
            {
                //Debug.Log("Hello");
                PlayerPlat = true;
                StartCoroutine(buttonDown());
            }
        }

        else if ((this.gameObject.tag == "PlatTier3") && (characterManager.CubeT3PowerUp == true))
        {
            if (cube.gameObject.tag == "Player")
            {
                //Debug.Log("Hello");
                PlayerPlat = true;
                StartCoroutine(buttonDown());
            }
        }
    }

    public void OnTriggerExit(Collider cube)
    {
        if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3")
        {
            CubeBool = false;
            cubeWeight = 0;
        }

        else if (cube.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            PlayerPlat = false;
            StartCoroutine(buttonUp());
        }
    }

    public void OnTriggerStay(Collider cube)
    {
        if (cube.gameObject == null)
        {
            Debug.Log("There are no cubes");
            cubeWeight = 0;
        }
    }

    IEnumerator buttonDown()
    {
        if (this.gameObject.tag == "PlatTier1")
        {
            if (characterManager.Tier1PlateSpeech == false)
            {
                Debug.Log("Explaining T1 Platform");
                //Play Audio Explaining platform
                characterManager.Tier1PlateSpeech = true;
            }
        }

        if (this.gameObject.tag == "PlatTier2")
        {
            if (characterManager.Tier2PlateSpeech == false)
            {
                //Play Audio Explaining platform
                characterManager.Tier2PlateSpeech = true;
            }
        }

        if (this.gameObject.tag == "PlatTier3")
        {
            if (characterManager.Tier3PlateSpeech == false)
            {
                //Play Audio Explaining platform
                characterManager.Tier3PlateSpeech = true;
            }
        }

        anim.SetBool("ButtonDown", true);
        anim.SetBool("ButtonUp", false);

        yield return new WaitForSeconds(0.5f);
        PlatActivate = true;
    }

    IEnumerator buttonUp()
    {
        anim.SetBool("ButtonDown", false);
        anim.SetBool("ButtonUp", true);

        //yield return new WaitForSeconds(1f);
        yield return null;
        PlatActivate = false;
    }

    //private void OnTriggerStay(Collider cube)
    //{
    //if (this.gameObject.tag == "PlatTier1")
    //{
    //if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is on platform");

    //buttonDown();
    //}
    //}

    //if (this.gameObject.tag == "PlatTier2")
    //{
    //if (cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is on platform");

    //buttonDown();
    //}
    //}

    //if (this.gameObject.tag == "PlatTier3")
    //{
    //if (cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is on platform");

    //buttonDown();
    //}

    //else if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2")
    //{
    //T3PlatCol = true;
    //Debug.Log("Hey");
    //}

    //else
    //{
    //T3PlatCol = false;
    //}

    //if (cube.gameObject.tag == "CubeTier1" && cube.gameObject.tag == "CubeTier2")
    //{
    //Debug.Log("Cube is on platform");
    //buttonDown();
    //}
    //}
    //}

    //private void OnTriggerExit(Collider cube)
    //{
    //if (this.gameObject.tag == "PlatTier1")
    //{
    //if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is not on platform");

    //buttonUp();
    //}
    //}

    //if (this.gameObject.tag == "PlatTier2")
    //{
    //if (cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is not on platform");

    //buttonUp();
    //}
    //}

    //if (this.gameObject.tag == "PlatTier3")
    //{
    //if (cube.gameObject.tag == "CubeTier3" || cube.gameObject.tag == "Player")
    //{
    //Debug.Log("Cube is not on platform");

    //buttonUp();
    //}
    //}
    //} 


}
