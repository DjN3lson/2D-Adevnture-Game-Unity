using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void adventureMode(){
        SceneManager.LoadSceneAsync(1); //start with Level 1
    }
    public void survivalMode(){
        SceneManager.LoadSceneAsync(2); //Survival Level
    }
    public void quit(){
        Application.Quit();
    }
}
