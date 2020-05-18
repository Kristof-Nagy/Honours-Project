using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting_Tree : MonoBehaviour
{
    public Animator transition;

    Missions mission;

    SpriteRenderer tree1;
    SpriteRenderer tree2;
    SpriteRenderer tree3;

    // Start is called before the first frame update
    void Start()
    {
        tree1 = GameObject.Find("PTree").GetComponent<SpriteRenderer>();
        tree2 = GameObject.Find("PTree2").GetComponent<SpriteRenderer>();
        tree3 = GameObject.Find("PTree3").GetComponent<SpriteRenderer>();

        mission = FindObjectOfType<Missions>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(mission.mission4 == true)
            {
                if (this.name == "PHighlight")
                {
                    
                    StartCoroutine(Planting_Anim(tree1, "Plant",1));
                }

                if (this.name == "PHighlight2")
                {
                    StartCoroutine(Planting_Anim(tree2, "Plant2", 1));
                }

                if (this.name == "PHighlight3")
                {
                    StartCoroutine(Planting_Anim(tree3, "Plant3", 1));
                }
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Planting_Anim(SpriteRenderer tree, string trigger_name, int sec)
    {
        tree.enabled = true;
        transition.SetTrigger(trigger_name);
        //tree.enabled = true;

        yield return new WaitForSeconds(sec);

    }
}
