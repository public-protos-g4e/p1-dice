using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int currentLevel;
    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        Debug.Log("Stsart UI scene");

        uiManager.HideMainMenu();
        uiManager.HideIngameUI();
        uiManager.HideMessageText();

        uiManager.ShowMainMenu();
        
        this.LoadScene(currentLevel);
    }

    public void StartGame()
    {
        uiManager.HideMainMenu();
        uiManager.ShowIngameUI();

        Debug.Log("StartGame now");

        if(this.playerPrefab != null) {
            Debug.Log("Create Player instance");
        } else {
            Debug.Log("PlayerPrefab has not been defined");
        }
    }

    private void LoadScene(int level)
    {
        string oldLevelName     = "Level" + (level - 1);
        string currentLevelName = "Level" + level;
        
        Scene scene = SceneManager.GetSceneByName(oldLevelName);
        if(scene.IsValid()) {
            SceneManager.UnloadSceneAsync(scene);
        }

        SceneManager.LoadScene(currentLevelName, LoadSceneMode.Additive);
    }

    public void SeeLeaderboard()
    {
        Debug.Log("SeeLeaderboard now");
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
#if UNITY_EDITOR
        Debug.Log("ExitGame Editor");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("Application.Quit()");
        Application.Quit();
#endif
    }

    public void ShowMainMenu()
    {
        Debug.Log("ShowMainMenu now");
        uiManager.ShowMainMenu();
    }
}
