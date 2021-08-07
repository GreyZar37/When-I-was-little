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

    public float OptionsTabOpenTime;
    public float OptionsTabCloseTime;

    //MainMenu

    //All Buttons in Main Menu
    public GameObject PlayBtn;
    public GameObject OptionsBtn;
    public GameObject QuitBtn;

    public bool StartOptionsMenuOpenCooldown = false;
    public bool StartOptionsMenuCloseCooldown = false;

    public void Play()
    {
        SceneManager.LoadScene("Hallway");
        KeysCollect.keysCollected = 0;
        GameManager.wasInBedroom = false;
    }

    public void Options()
    {
        PlayBtn.SetActive(false);
        OptionsBtn.SetActive(false);
        QuitBtn.SetActive(false);
        StartOptionsMenuOpenCooldown = true;
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
        if (StartOptionsMenuOpenCooldown == true)
        {
            OptionsTabOpenTime -= Time.deltaTime;
        }

        if (OptionsTabOpenTime <= 0)
        {
            OptionsTab.SetActive(true);
            StartOptionsMenuOpenCooldown = false;
        }

        if (StartOptionsMenuCloseCooldown == true)
        {
            OptionsTabCloseTime -= Time.deltaTime;
        }
        if (OptionsTabCloseTime <= 0f)
        {
            PlayBtn.SetActive(true);
            OptionsBtn.SetActive(true);
            QuitBtn.SetActive(true);
        }
        volumetext = (Volume.value * 200).ToString("F0");
        volumetextobject.text = "Volume: " + volumetext + "%";
    }

    public void BackBtn()
    {
        OptionsTab.SetActive(false);
        PlayBtn.SetActive(true);
        OptionsBtn.SetActive(true);
        QuitBtn.SetActive(true);
    }

    //DeathScreen

    public void RestartBtn()
    {
        SceneManager.LoadScene("Hallway");
        KeysCollect.keysCollected = 0;
        GameManager.wasInBedroom = false;
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
