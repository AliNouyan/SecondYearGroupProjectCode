using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockResetButton : MonoBehaviour {

    public GameObject Cube;
    public GameObject CubePrefab;
    public GameObject CubeSpawnLocation;
    public GameObject StoppingButtonObject;
    public bool StoppingObject;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ResetCube()
    {
        if(StoppingObject == true)
        {
            if (StoppingButtonObject.GetComponent<PlatformController>().PlatActivate == false)
            {
                Debug.Log("Resetting the cube");
                anim.SetBool("LeverAnimationBool", true);
                StartCoroutine(ResetWait());
            }
            else if (StoppingButtonObject.GetComponent<PlatformController>().PlatActivate == true)
            {
                var manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterManager>();
                manager.stopAudio();
                manager.LeverDeactivated.Play();
            }
        }
        else
        {
            Debug.Log("Resetting the cube");
            anim.SetBool("LeverAnimationBool", true);
            StartCoroutine(ResetWait());
        }
       
        //Destroy(Cube);
        //Cube = Instantiate(CubePrefab, CubeSpawnLocation.transform.position, CubeSpawnLocation.transform.rotation);
    }

    IEnumerator ResetWait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(Cube);
        Cube = Instantiate(CubePrefab, CubeSpawnLocation.transform.position, CubeSpawnLocation.transform.rotation);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("LeverAnimationBool", false);
    }
}
