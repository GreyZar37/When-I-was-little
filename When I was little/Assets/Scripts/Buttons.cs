using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Options
    public GameObject OptionsTab;

    public Scrollbar Volume;
    string volumetext;

    public Text volumetextobject;

    //MainMenu
    public GameObject MainMenuButtons;

    public void Play()
    {
        SceneManager.LoadScene("Hallway");
    }

    public void Options()
    {
        //MainMenuButtons.SetActive(false);
        OptionsTab.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Options

    void Start()
    {
        
    }

    void Update()
    {
        volumetext = (Volume.value * 200).ToString("F0");
        volumetextobject.text = "Volume: " + volumetext + "%";
    }

    public void BackBtn()
    {
        OptionsTab.SetActive(false);
        MainMenuButtons.SetActive(true);
    }

    //DeathScreen

    public void RestartBtn()
    {
        SceneManager.LoadScene("Hallway");
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
