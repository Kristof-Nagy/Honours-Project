using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Labels : MonoBehaviour
{

    SpriteRenderer read_label;
    SpriteRenderer pick_up_label;
    SpriteRenderer drive_label;
    SpriteRenderer switch_label;
    SpriteRenderer switch_car_label;
    SpriteRenderer forest_level_label;
    SpriteRenderer plant_label;
    SpriteRenderer extinguish_label;
    SpriteRenderer secret_label;





    public bool dialogue_stop = false;
    public bool car_switched = false;
    public bool now_switch_colour = false;

    public SpriteRenderer red_car_colour;
    public Sprite green_car_colour;

    Missions missions;

    private void Start()
    {
        read_label = GameObject.Find("Read_Label").GetComponent<SpriteRenderer>();
        pick_up_label = GameObject.Find("Pick_Up_Label").GetComponent<SpriteRenderer>();
        drive_label = GameObject.Find("Drive_Label").GetComponent<SpriteRenderer>();
        switch_label = GameObject.Find("Switch_Label").GetComponent<SpriteRenderer>();
        switch_car_label = GameObject.Find("Switch_Car_Label").GetComponent<SpriteRenderer>();
        forest_level_label = GameObject.Find("Forest_Label").GetComponent<SpriteRenderer>();
        plant_label = GameObject.Find("Plant_Label").GetComponent<SpriteRenderer>();
        extinguish_label = GameObject.Find("Extinguish_Label").GetComponent<SpriteRenderer>();
        secret_label = GameObject.Find("Secret_Label").GetComponent<SpriteRenderer>();

        missions = FindObjectOfType<Missions>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (this.tag == "Drive")
        {
            Switch_Car_Colour();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (read_label.enabled == false &&
            pick_up_label.enabled == false &&
            drive_label.enabled == false &&
            switch_label.enabled == false &&
            switch_car_label.enabled == false &&
            forest_level_label.enabled == false &&
            plant_label.enabled == false &&
            extinguish_label.enabled == false &&
            secret_label.enabled == false)
        {
            if (this.tag == "Read")
            {
                read_label.enabled = true;
            }
            else if (this.tag == "Pick_Up" && missions.mission2 == true)
            {
                pick_up_label.enabled = true;
            }
            else if (this.tag == "Drive")
            {
                drive_label.enabled = true;
                if (missions.mission1 == true && car_switched == false)
                {
                    if(dialogue_stop == false)
                    {
                        dialogue_stop = true;
                        DialogueManager dialog = FindObjectOfType<DialogueManager>();
                        dialog.Start_Dialogue();
                    }
                    switch_car_label.enabled = true;
                    now_switch_colour = true;
                }
            }
            else if (this.tag == "Switch")
            {
                switch_label.enabled = true;
            }
            else if (this.tag == "NextLevel")
            {
                forest_level_label.enabled = true;
            }

            else if (this.tag == "Plant" && missions.mission4 == true)
            {
                plant_label.enabled = true;
            }

            else if (this.tag == "Fire" && missions.mission3 == true)
            {
                extinguish_label.enabled = true;
            }

            else if (this.tag == "Secret")
            {
                secret_label.enabled = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        TurnOffLabels();
    }

    public void TurnOffLabels()
    {
        read_label.enabled = false;
        pick_up_label.enabled = false;
        drive_label.enabled = false;
        switch_label.enabled = false;
        switch_car_label.enabled = false;
        forest_level_label.enabled = false;
        plant_label.enabled = false;
        extinguish_label.enabled = false;
        secret_label.enabled = false;
    }

    private void Switch_Car_Colour()
    {
        if (car_switched == false && now_switch_colour == true)
        {
             if (Input.GetKeyDown(KeyCode.E))
             {
                  red_car_colour.sprite = green_car_colour;
                  car_switched = true;
             }
        }
    }
}
