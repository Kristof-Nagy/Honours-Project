using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Animator transition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enabled)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Destroy(this.gameObject);
            }
            if (Input.GetKey(KeyCode.E) && transition != null)
            {
                StartCoroutine(waitxseconds(1));
            }
        }
    }
    IEnumerator waitxseconds(int sec)
    {
        transition.SetTrigger("Fire_Ext");
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }
}
