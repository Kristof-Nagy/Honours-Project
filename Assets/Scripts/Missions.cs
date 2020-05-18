using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class handles the missions. The on and off is switched with their representative boolean along with their finished boolean
//Mission 1 is turning the lights off at home
//Mission 2 is picking up the trash on the floor
public class Missions : MonoBehaviour
{
    // Level 1
    [HideInInspector]
    public bool mission1 = false;
    [HideInInspector]
    public bool mission1_finished = false;
    [HideInInspector]
    public bool mission2 = false;
    [HideInInspector]
    public bool mission2_finished = false;

    // Level 2
    
    public bool mission3 = false;
    [HideInInspector]
    public bool mission3_finished = false;
    [HideInInspector]
    public bool mission4 = false;
    [HideInInspector]
    public bool mission4_finished = false;


    public GameObject current_object;
    public GameObject mission_canvas;
    public Text missions_text;

    private void Update()
    {
        // Getting close to an interactable object for information purpose such as a crumbled newspaper on the floor, or news placed in the show window
        if (current_object != null && Input.GetKeyDown("e"))
        {
            // Mission 1
            // Turn off electricity
            // Setting up mission1 text and turn on mission1 bool
            if (mission1 == false && mission1_finished == false && current_object.name == "Newspaper_Wall")
            {
                Mission1();
                mission1 = true;
            }

            // Mission 2
            // Pick up trash
            // Setting up mission2 text and turn on mission2 bool
            if (mission2 == false && mission2_finished == false && current_object.name == "Crumbled_Newspaper")
            {
                Mission2();
                mission2 = true;
                Pick_Up_Enable();
            }

            // Mission 3
            // Putting out fire of burning trees
            // Setting up mission3 text and turn on mission3 bool
            if (mission3 == false && mission3_finished == false && current_object.name == "Tree_Note")
            {
                Mission3();
                mission3 = true;
                Burning_Enable();
            }

            // Mission 4
            // Planting new trees
            // Setting up mission4 text and turn on mission4 bool
            if (mission4 == false && mission4_finished == false && current_object.name == "Floor_Note")
            {
                Mission4();
                mission4 = true;
                Planting_Enable();
            }
        }

        Enable_Disable_Canvas();
        Mission1Finish(mission1_finished);
        Mission2Finish();
        Mission3_Finished();
        Mission4_Finished();
    }
    // END UPDATE

    // Mission details ******************************************************

    // ~~~~~~~~~~~~~~~~~~~
    // All about mission 1
    // ~~~~~~~~~~~~~~~~~~~

    private void Mission1()
    {
        missions_text.text += "\n" + "- Turn off the lights at home";
        //missions_text.text += "\n" + "- Kapcsold le a lámpát otthon";
        
    }

    // Checking if Mission 1 has been done
    public void Mission1Finish(bool finished)
    {
        if (mission1 == true)
        {
            if (finished)
            {
                if (mission2 == true)
                {
                    missions_text.text = "To Do List:" + "\n" + "- Pick up the trash in the city";
                    //missions_text.text = "Teendők:" + "\n" + "- Szedd össze a szemetet a városban";
                }
                else
                {
                    missions_text.text = "To Do List:";
                    //missions_text.text = "Teendők:";
                }

                mission1 = false;
                mission1_finished = true;
            }
        }
    }

    // END MISSION 1
    // ============================================================


    // ~~~~~~~~~~~~~~~~~~~
    // All about mission 2
    // ~~~~~~~~~~~~~~~~~~~

    public void Mission2()
    {
        missions_text.text += "\n" + "- Pick up the trash in the city";
        //missions_text.text += "\n" + "- Szedd össze a szemetet a városban";
    }

    // Checking if Mission 2 has been done
    private void Mission2Finish()
    {
        if (mission2 == true)
        {
            if (GameObject.FindGameObjectWithTag("Pick_Up") == null)
            {                
                if (mission1 == true)
                {
                    missions_text.text = "To Do List:" + "\n" + "- Turn off the lights at home";
                    //missions_text.text = "Teendők:" + "\n" + "- Kapcsold le a lámpát otthon";
                }
                else
                {
                    missions_text.text = "To Do List:";
                    //missions_text.text = "Teendők:";
                }

                mission2 = false;
                mission2_finished = true;
            }
        }
    }

    // Making the script enable with all the object that has a tag "Pick_Up", so the player can complete missions
    private void Pick_Up_Enable()
    {
        GameObject[] pick_up_list = GameObject.FindGameObjectsWithTag("Pick_Up");
        foreach (GameObject gameobject in pick_up_list)
        {
            Pick_Up pick_up_script = gameobject.GetComponent<Pick_Up>();
            pick_up_script.enabled = true;
        }
    }

    // END MISSION 2
    // ============================================================


    // ~~~~~~~~~~~~~~~~~~~
    // All about mission 3
    // ~~~~~~~~~~~~~~~~~~~

    private void Mission3()
    {
        missions_text.text += "\n" + "- Put out the fire";
        //missions_text.text += "\n" + "- Oltsd el a tüzet";
    }

    private void Mission3_Finished()
    {
        if (mission3 == true)
        {
            if (GameObject.FindGameObjectWithTag("Fire") == null)
            {
                if (mission4 == true)
                {
                    missions_text.text = "To Do List:" + "\n" + "- Plant new trees";
                    //missions_text.text = "Teendők:" + "\n" + "- Ültess fát";
                }
                else
                {
                    missions_text.text = "To Do List:";
                    //missions_text.text = "Teendők:";
                }

                mission3 = false;
                mission3_finished = true;
            }
        }
    }

    private void Burning_Enable()
    {
        // Pickup destroys the pick up object, so that can be used for disappearing "fire"
        GameObject[] burning_list = GameObject.FindGameObjectsWithTag("Fire");
        foreach (GameObject gameobject in burning_list)
        {
            gameobject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // END MISSION 3
    // ============================================================


    // ~~~~~~~~~~~~~~~~~~~
    // All about mission 4
    // ~~~~~~~~~~~~~~~~~~~

    private void Mission4()
    {
        missions_text.text += "\n" + "- Plant new trees";
        //missions_text.text += "\n" + "- Ültess fát";
    }

    private void Mission4_Finished()
    {
        if (mission4 == true)
        {
            if (GameObject.FindGameObjectWithTag("Plant") == null)
            {
                if (mission3 == true)
                {
                    missions_text.text = "To Do List:" + "\n" + "- Put out the fire";
                    //missions_text.text = "Teendők:" + "\n" + "- Oldtsd el a tüzet";
                }
                else
                {
                    missions_text.text = "To Do List:";
                    //missions_text.text = "Teendők:";
                }

                mission4 = false;
                mission4_finished = true;
            }
        }
    }

    private void Planting_Enable()
    {
        // Pickup destroys the pick up object, so that can be used for disappearing "fire"
        GameObject[] burning_list = GameObject.FindGameObjectsWithTag("Plant");
        foreach (GameObject gameobject in burning_list)
        {
            gameobject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // END MISSION 4
    // ============================================================

    // END MISSION DETAILS******************************************************

    // Checking wheter any of the missions are active
    // If any is then display canvas with missions
    void Enable_Disable_Canvas()
    {
        if (mission1 || mission2 || mission3 || mission4)
        {
            mission_canvas.SetActive(true);
        }
        else
        {
            mission_canvas.SetActive(false);
        }
    }
}
