using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class makes the mission object (newspapers) to disappear, also starting the dialouges after destroying the objects
public class Destroy : MonoBehaviour {
    
    public DialogueManager mission_dialogues;

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);

            mission_dialogues = FindObjectOfType<DialogueManager>();
            mission_dialogues.Start_Dialogue();
        }
	}
}
