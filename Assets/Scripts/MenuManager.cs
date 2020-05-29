using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject control;
    public GameObject settings;
   
   
    public void reTry()
    {
        
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Debug.Log("Game Shut Down");
        Application.Quit();
       
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void startGame()
    {

        SceneManager.LoadScene("Game");
    }

    public void ShowControl()
    {
        control.SetActive(true);
    }

    public void HideControl()
    {
        control.SetActive(false);
    }
    public void ShowSettings()
    {
        settings.SetActive(true);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
