using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //SINGLETON
    private static LevelManager singleton;

    public GameObject player;
    public GameObject spawn_pos;

    public GameObject[] do_not_destroy;

    public static GameObject collided_obj;

    public LevelLoaderMainMenu nextlvl;

    DialogueManager dialog;

    public Text missions_text;

    bool is_credit = false;

    private void Awake()
    {
        //SINGLETON
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (GameObject gO in do_not_destroy)
        {
            DontDestroyOnLoad(gO);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialog = FindObjectOfType<DialogueManager>();
        player.transform.position = spawn_pos.transform.position;
        
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {
        if(collided_obj != null)
        {
            if (collided_obj.name == "Players_Car")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Activate_Labels labels = FindObjectOfType<Activate_Labels>();
                    labels.TurnOffLabels();
                    nextlvl.LoadNextLevel("level_1_room");
                }
            }
            if (collided_obj.name == "BackToCity")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Activate_Labels labels = FindObjectOfType<Activate_Labels>();
                    labels.TurnOffLabels();
                    nextlvl.LoadNextLevel("level_1");
                }
            }

            if (collided_obj.name == "Forest_Level_Collider")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Activate_Labels labels = FindObjectOfType<Activate_Labels>();
                    labels.TurnOffLabels();
                    missions_text.text = "";
                    Reset_Level1Missions();
                    nextlvl.LoadNextLevel("level_2");
                }
            }

            if (collided_obj.name == "Fina_Words_Collider")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    is_credit = true;
                    Activate_Labels labels = FindObjectOfType<Activate_Labels>();
                    labels.TurnOffLabels();
                    missions_text.text = "";
                    Reset_Level2Missions();
                    nextlvl.LoadNextLevel("credits");
                }
            }
        }

        //Not optimal, but could not make this happen after changing the scenes
        if (spawn_pos == null)
        {
            if (player != null)
            {
                spawn_pos = GameObject.Find("Player_Position");
                player.transform.position = spawn_pos.transform.position;
            }
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (is_credit != true)
        {
            spawn_pos = GameObject.Find("Spawn_Position");
            player.transform.position = spawn_pos.transform.position;
            nextlvl = FindObjectOfType<LevelLoaderMainMenu>();

            dialog.Start_Dialogue();
        }
        else
        {
            is_credit = false;
            Reset_Game();
        }
               
    }

    private void Reset_Game()
    {
        Missions missions = FindObjectOfType<Missions>();

        missions.mission1 = false;
        missions.mission2 = false;
        missions.mission3 = false;
        missions.mission4 = false;

        missions.mission1_finished = false;
        missions.mission2_finished = false;
        missions.mission3_finished = false;
        missions.mission4_finished = false;

        dialog.start1_bubble_stopper = false;
        dialog.start1r_bubble_stopper = false;
        dialog.start2_bubble_stopper = false;
        dialog.mission1_bubble_stopper = false;
        dialog.mission2_bubble_stopper = false;
        dialog.mission3_bubble_stopper = false;
        dialog.mission4_bubble_stopper = false;
        dialog.mission1_car_bubble_stopper = false;
    }

    private void Reset_Level1Missions()
    {
        Missions missions = FindObjectOfType<Missions>();

        missions.mission1 = false;
        missions.mission2 = false;

        missions.mission1_finished = false;
        missions.mission2_finished = false;
    }

    private void Reset_Level2Missions()
    {
        Missions missions = FindObjectOfType<Missions>();

        missions.mission3 = false;
        missions.mission4 = false;

        missions.mission3_finished = false;
        missions.mission4_finished = false;
    }
}
