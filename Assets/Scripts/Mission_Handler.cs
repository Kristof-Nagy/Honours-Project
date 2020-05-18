using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Handler : MonoBehaviour
{
    public Missions missions;

    private void Start()
    {
        missions = FindObjectOfType<Missions>();
    }

    public void Set_Mission1_Finish()
    {
        missions.Mission1Finish(true);
    }
}
