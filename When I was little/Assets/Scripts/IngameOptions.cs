using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameOptions : MonoBehaviour
{

    public GameObject OptionsMenuIngame;
    public bool OptionsMenuActive = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && OptionsMenuActive == false)
        {
            OptionsMenuIngame.SetActive(true);
            OptionsMenuActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && OptionsMenuActive == true)
        {
            OptionsMenuIngame.SetActive(false);
            OptionsMenuActive = false;
        }
    }

    public void OptionsMenuClose()
    {
        OptionsMenuIngame.SetActive(false);
        OptionsMenuActive = false;
    }

    public void ResumeBtn() 
    {
        OptionsMenuIngame.SetActive(false);
        OptionsMenuActive = false;
    }


    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void RestartBtn()
    {
        SceneManager.LoadScene("Hallway");
        GameManager.wasInBedroom = false;
        KeysCollect.keysCollected = 0;
    }
}
