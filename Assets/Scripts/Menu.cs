using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //making a reference to UI resume button in our main menu scene
    public Button resumeBtn;

    private void Awake()
    {

        
    }

    private void Start()
    {
        resumeBtn.interactable = false;

        bool prev = false;
        //1. check if there is a prev game or not
        for (int i = 0; i < 9; i++)
        {

            if (PlayerPrefs.HasKey(System.Convert.ToString(i)))
            {
                prev = true;
                break;
            }

        }

        //case 1. -> there is "No" prev game -> make resume btn as disable
        if (prev)
        {
            Debug.Log("Resume Button is enabled, since, there is a prev game!");
            resumeBtn.interactable = true;
        }

        //else -> leave it disabled
    }

    public void NewGame()
    {
        //empty the playerprefs
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        //loads next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {
        //resume btn is clickable -> means there is a prev game -> so, loading the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Debug.Log("You've Quit the Game!");
        Application.Quit();
    }

    public void Settings()
    {   //loads main menu scene which is one scene before current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
