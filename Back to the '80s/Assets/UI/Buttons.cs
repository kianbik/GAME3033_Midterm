using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Buttons : MonoBehaviour
{
   
    public GameObject MainMenuCanvas;
    
    public GameObject CreditsCanvas;
    
    public GameObject HowToPlayCanvas;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("MainLevel");
    }
   
    public void OnCreditsClicked()
    {
        CreditsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

   
    public void OnHowToPlayClicked()
    {
        HowToPlayCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

    public void OnBackClicked()
    {
       
        CreditsCanvas.SetActive(false);
       
        HowToPlayCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

   
}
