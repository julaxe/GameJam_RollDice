using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject creditsRef;
    [SerializeField] private GameObject mainMenuRef;
    

    public void MainMenuToCredits()
    {
        mainMenuRef.SetActive(false);
        creditsRef.SetActive(true);
    }

    public void CreditsToMainMenu()
    {
        mainMenuRef.SetActive(true);
        creditsRef.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }



}
