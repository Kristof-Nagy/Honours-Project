using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

    //SINGLETON
    private static SmoothFollow singleton;


    public GameObject objectToFollow;

    public float speed = 2.0f;
    public float min_pos = 0f;
    public float max_pos = 0f;
    public float min_left = 0f;
    public float max_right = 0f;

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
    }

    private void Start()
    {
        objectToFollow = GameObject.Find("Character");
        Vector3 position = this.transform.position;

        position.y = objectToFollow.transform.position.y + 2f;
        position.x = objectToFollow.transform.position.x;

        this.transform.position = position;
    }

    void FixedUpdate()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y + 2f, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        if (position.y > max_pos)
        {
            position.y = max_pos;
        }

        if (position.y < min_pos)
        {
            position.y = min_pos;
        }

        if (position.x < min_left)
        {
            position.x = min_left;
        }

        if (position.x > max_right)
        {
            position.x = max_right;
        }

        this.transform.position = position;
    }
}