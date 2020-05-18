using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represent interaction between player and mission objects
public class PlayerInteraction : MonoBehaviour
{
    public Rigidbody2D player_rb2d;     //Rigid Body to track if player collides with something

    public Missions missions;           //Mission script to check if there is a mission object to interact with
    public Spawner spawner;             //Spawner script to send the current mission object

    private void Start()
    {
        missions = FindObjectOfType<Missions>();
        spawner = FindObjectOfType<Spawner>();
    }

    void Update()
    {
        //If player presses "e" and there is a mission object nearby, then spawn the mission object
        //HOW IT WORKS: Check_If_Spawned() denies additional spawns, player will be unable to move until mission object is destroyed
        //aka "stop being read", making spawn_obj true to spawn one and send through the mission object
        if (Input.GetKeyDown(KeyCode.E) && Check_If_Spawned() == false)
        {
            if (missions.current_object != null)
            {
                player_rb2d = GameObject.Find("Character").GetComponent<Rigidbody2D>();
                player_rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

                spawner.spawn_obj = true;
                spawner.interacted_item = missions.current_object;
            }
        }

        //If escape button is pressed release player freeze
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player_rb2d = GameObject.Find("Character").GetComponent<Rigidbody2D>();
            player_rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnTriggerEnter2D(Collider2D collided_obj)
    {
        if (!missions)
        {
            missions = FindObjectOfType<Missions>();
        }
        missions.current_object = this.gameObject;
        LevelManager.collided_obj = this.gameObject;
    }

    void OnTriggerExit2D(Collider2D collided_obj)
    {
        missions.current_object = null;
        LevelManager.collided_obj = null;
    }

    //Denies additional spawns. Since there is currently 2 object using the same script once spawning, once spawning is available it will run twice!
    public bool Check_If_Spawned()
    {
        GameObject newspaper = GameObject.FindGameObjectWithTag("Newspaper");

        if (newspaper == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
