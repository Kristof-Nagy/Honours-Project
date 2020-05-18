using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the spawning
public class Spawner : MonoBehaviour
{
    public GameObject player;               //Player object's position
    public GameObject interacted_item;      //The item that has the player interacted with

    public GameObject newspaper;            //Newspaper gameobject to spawn
    public GameObject crumbled_newspaper;   //Crumbled newspaper gameobject to spawn
    public GameObject tree_note;   //Crumbled newspaper gameobject to spawn
    public GameObject floor_note;   //Crumbled newspaper gameobject to spawn

    public bool spawn_obj = false;          //Boolean to keep the amount of spawning at bay

    // Update is called once per frame
    void Update ()
    {
        //If spawning is allowed
        if (spawn_obj == true)
        {
            spawn_obj = false;

            player = GameObject.Find("Character");
            //If interacted item is "Newspaper_Wall", spawn that
            if (interacted_item.name == "Newspaper_Wall")
            {
                Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
                Instantiate(newspaper, position, new Quaternion(0, 0, 0, 0));
            }

            //If interacted item is "Crumbled_Newspaper", spawn that
            if (interacted_item.name == "Crumbled_Newspaper")
            {
                Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
                Instantiate(crumbled_newspaper, position, new Quaternion(0, 0, 0, 0));
            }

            
            //If interacted item is "Tree_Note", spawn that
            if (interacted_item.name == "Tree_Note")
            {
                Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
                Instantiate(tree_note, position, new Quaternion(0, 0, 0, 0));
            }

            //If interacted item is "Floor_Note", spawn that
            if (interacted_item.name == "Floor_Note")
            {
                Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
                Instantiate(floor_note, position, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
