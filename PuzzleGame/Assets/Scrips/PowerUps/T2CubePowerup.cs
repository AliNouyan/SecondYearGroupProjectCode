using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2CubePowerup : MonoBehaviour {

    CharacterManager characterManager;

    // Use this for initialization
    void Start () {
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        characterManager = GameController.GetComponent<CharacterManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 35f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            if(characterManager.CubeT2PowerUp == false)
            {
                Destroy(this.gameObject);
                characterManager.CubeT2PowerUp = true;
            }
        }
    }
}
