using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public GameObject helpMenu;

    public void playButton()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    public void HelpButton()
    {
        helpMenu.SetActive(true);
    }
    public void ExitHelpButton()
    {
        helpMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }


    void Update()
    {
        
    }
}
