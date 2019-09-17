using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    Cube CubeScript;
    Collider CubeCol;

    public int cubeWeight;
    public int cube2Weight;
    public int CombinedWeight;

    bool secondCube = false;
    bool secondCubeExit = false;

    // Use this for initialization
    void Start () {
        CubeCol = this.gameObject.GetComponent<Collider>();
        Debug.Log(CubeCol);

        if (this.gameObject.tag == "CubeTier1")
        {
            cubeWeight = 100;
        }

        if (this.gameObject.tag == "CubeTier2")
        {
            cubeWeight = 150;
        }

        if (this.gameObject.tag == "CubeTier3")
        {
            cubeWeight = 250;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(secondCube == false)
        {
            CombinedWeight = cubeWeight;
        }
	}

    private void OnCollisionEnter(Collision cube)
    {
        if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3")
        {
            CubeScript = cube.gameObject.GetComponent<Cube>();
            cube2Weight = CubeScript.cubeWeight;
            //Debug.Log(cube2Weight);

            CombinedWeight = cubeWeight + cube2Weight;
            Debug.Log(gameObject + " " + CombinedWeight);

            if (this.gameObject.tag == "CubeTier1" || this.gameObject.tag == "CubeTier2")
            {
                if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2")
                {
                    secondCube = true;
                }
            }
        }

        else
        {
            //CombinedWeight = cubeWeight;
        }
    }

    private void OnTriggerStay(Collider platform)
    {
        if(this.gameObject.tag == "CubeTier1" || this.gameObject.tag == "CubeTier2")
        {
            Debug.Log(this.gameObject.tag);
            if(platform.gameObject.tag == "PlatTier3")
            {
                Debug.Log(platform.gameObject.tag);
                if (secondCube == true)
                {
                    platform.gameObject.GetComponent<PlatformController>().OnTriggerEnter(CubeCol);
                    Debug.Log(secondCube);
                    secondCube = false;
                }

                else if(secondCubeExit == true)
                {
                    platform.gameObject.GetComponent<PlatformController>().cubeWeight = cubeWeight;
                    secondCubeExit = false;
                }
            }
        }
    }

    private void OnCollisionExit(Collision cube)
    {
        if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2" || cube.gameObject.tag == "CubeTier3")
        {
            CubeScript = cube.gameObject.GetComponent<Cube>();
            cube2Weight = CubeScript.cubeWeight;
            //Debug.Log(cube2Weight);

            CombinedWeight = CombinedWeight - cube2Weight;
            Debug.Log(gameObject + " " + CombinedWeight);

            if (this.gameObject.tag == "CubeTier1" || this.gameObject.tag == "CubeTier2")
            {
                if (cube.gameObject.tag == "CubeTier1" || cube.gameObject.tag == "CubeTier2")
                {
                    CubeCol = cube.gameObject.GetComponent<Collider>();
                    Debug.Log(CubeCol);
                    secondCubeExit = true;
                }
            }
        }
    }
}
