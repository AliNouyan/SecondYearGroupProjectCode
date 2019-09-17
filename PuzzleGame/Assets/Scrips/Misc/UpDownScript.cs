using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownScript : MonoBehaviour {

    public float MaxHeight;
    public float MinHeight;
    public float Speed;

    Vector3 MaxVector;
    Vector3 MinVector;
    Vector3 StoredPos;

	// Use this for initialization
	void Start () {
		MaxVector = new Vector3(transform.position.x, MaxHeight, transform.position.z);
        MinVector = new Vector3(transform.position.x, MinHeight, transform.position.z);
        StoredPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(StoredPos + (transform.up * MinHeight), StoredPos + (transform.up * MaxHeight), Mathf.PingPong(Time.time * (Speed), 1f));
    }
}
