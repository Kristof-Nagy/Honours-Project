using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToCity : MonoBehaviour
{
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        LevelManager.collided_obj = this.gameObject;
    }
}
