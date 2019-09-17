using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour
{
    CharacterManager characterManager;
    GameObject Player;
    GameObject cube;
    // Use this for initialization
    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("CubeTier2");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        characterManager = GameController.GetComponent<CharacterManager>(); //gets information from script CharacterManager
        

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider player) //when inside collider
    {

        if (player.gameObject.tag == "Player") //when player is inside collider
        {
            if (characterManager.CubeT2PowerUp == true) //if powerup is obtained
            {
                characterManager.CubeT2PowerUp = false; //switches powerup off

                Destroy(cube.gameObject);


                //var Controller = Player.GetComponent("Controller");
                //if(Controller.CubeHit.Transform.tag == "CubeTier2")
                //{
                //    Debug.Log("Test");
                //}
            }


        }
    }
}
