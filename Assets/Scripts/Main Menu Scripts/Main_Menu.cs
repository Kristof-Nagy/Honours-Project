using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        LevelLoaderMainMenu first_lvl = FindObjectOfType<LevelLoaderMainMenu>();
        first_lvl.LoadNextLevel("level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
