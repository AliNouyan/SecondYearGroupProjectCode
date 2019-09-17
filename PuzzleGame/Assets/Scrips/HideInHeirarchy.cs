using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInHeirarchy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for(int count = 0; count < this.transform.childCount; count ++)
        {
            this.transform.GetChild(count).hideFlags = HideFlags.HideInHierarchy;
        }
        this.gameObject.hideFlags = HideFlags.HideInHierarchy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
