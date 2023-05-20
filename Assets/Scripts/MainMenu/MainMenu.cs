using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnNewGameClicked() 
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(1);
    }

    public void OnContinueGameClicked() 
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync(1);
    }

    private void DisableMenuButtons() 
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

}
