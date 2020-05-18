using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderMainMenu : MonoBehaviour
{

    // Animation handler & Level change
    //Animator
    public Animator transition;

    public void LoadNextLevel(string level_name)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadLevel("level_1"));
        }
        else
        {
            StartCoroutine(LoadLevel(level_name));
        }
    }

    IEnumerator LoadLevel(string level_name)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(level_name);
    }
}
