using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Launcher : MonoBehaviour
{

    public GameObject optionScreen;
    public GameObject menuButtons;
    public GameObject title; 
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(true);
        menuButtons.SetActive(true);
        optionScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeMenus()
    {
        title.SetActive(false);
        menuButtons.SetActive(false);
    }

    public void openMenus()
    {
        title.SetActive(true);
        menuButtons.SetActive(true);
    }

    public void openOptions()
    {
        closeMenus();
        optionScreen.SetActive(true);
    }

    public void closeOptions()
    {
        openMenus();
        optionScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
