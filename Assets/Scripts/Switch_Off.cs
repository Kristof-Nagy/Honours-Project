using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Off : MonoBehaviour
{
    // Lights to handle
    public GameObject light_hall;
    public GameObject light_bedroom;
    public GameObject light_bathroom;
    public GameObject light_kitchen;

    public GameObject[] all_lights;
    public int lights_counter = 0;

    private void Start()
    {
        all_lights = new GameObject[] { light_hall, light_bedroom, light_bathroom, light_kitchen };
    }

    private void Update()
    {
        if(lights_counter == 4)
        {
            Debug.Log("CSak akkor legyen itt ha minden villany lent van");
            Mission_Handler room_mission = FindObjectOfType<Mission_Handler>();
            room_mission.Set_Mission1_Finish();
            lights_counter = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Check_Light("h_Switch", light_hall);
        Check_Light("b_Switch", light_bedroom);
        Check_Light("ba_Switch", light_bathroom);
        Check_Light("k_Switch", light_kitchen);       
    }

    private void Check_Light(string switch_name, GameObject light_name)
    {
        if (this.name == switch_name)
        {
            if (Input.GetKeyDown(KeyCode.E) && light_name.active == true)
            {
                light_name.active = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && light_name.active == false)
            {
                light_name.active = true;
            }
        }

        lights_counter = 0;
        foreach (GameObject lights in all_lights)
        {
            if (lights.active == false)
            {
                lights_counter++;
            }
        }
    }
}
