using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentScore;
    [SerializeField] private GameObject player;
    private static UserData userData;

    void Start()
    {
        // Initialize UserData
        userData = SaveManager.LoadUserData();
        if(userData == null)
        {   
            //TODO: Gather the player's name
            userData = new UserData("Player", 0, new List<UserScore>());
            SaveManager.SaveUserData(userData);
        }
        Debug.Log("Stsart UI scene");

        uiManager.HideMainMenu();
        uiManager.HideIngameUI();
        uiManager.HideMessageText();

        uiManager.ShowMainMenu();
        
        this.LoadScene(currentLevel);
    }

    private void Update()
    {
        //...
    }

    public void StartGame()
    {
        uiManager.HideMainMenu();
        uiManager.ShowIngameUI();

        Debug.Log("StartGame now");

        if(this.player != null) {
            Debug.Log("Create Player instance");
            player.SetActive(true);
        } else {
            Debug.Log("Player has not been defined");
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

    public void GoToNextScene()
    {
        LoadScene(this.currentLevel + 1);
        uiManager.HideMessageText();
        uiManager.ShowIngameUI();
        player.SetActive(true);
        this.currentScore = 0;
    }

    public void AddScore(int score)
    {
        this.currentScore += score;
        
        uiManager.SetScore(this.currentScore);

        if(this.currentScore > 20) {
            player.SetActive(false);
            player.GetComponent<Transform>().position = Vector3.zero;

            uiManager.setMessagesMainText("Level Complete");
            uiManager.setMessagesSecondaryText("Go to next Label?");
            uiManager.ShowMessageText();
            uiManager.HideIngameUI();
            // uiManager.GetMessageButton().clickable = null;
            uiManager.GetMessageButton().text = "Go!!";
            uiManager.GetMessageButton().clickable.clicked += () => GameManager.Instance.GoToNextScene();
        }
    }

    public void SeeLeaderboard()
    {
        Debug.Log("SeeLeaderboard now");
        
        SaveManager.AddScoreToLeaderboard(userData, "Walter", 500);
        SaveManager.AddScoreToLeaderboard(userData, "Jesse", 200);
        SaveManager.AddScoreToLeaderboard(userData, "Skyler", 300);
        SaveManager.AddScoreToLeaderboard(userData, "Hank", 400);
        SaveManager.AddScoreToLeaderboard(userData, "Marie", 100);
        SaveManager.AddScoreToLeaderboard(userData, "Gus", 600);
        
        foreach (var userScore in userData.Leaderboard)
        {
            Debug.Log(userScore.Name + " " + userScore.Score);
        }

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
