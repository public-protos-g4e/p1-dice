using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private static UserData userData;

    void Start()
    {
        Debug.Log("GameManager Start");
        Debug.Log(Application.persistentDataPath);
        // Initialize UserData
        userData = SaveManager.LoadUserData();
        if(userData == null)
        {   
            //TODO: Gather the player's name
            userData = new UserData("Player", 0, new List<UserScore>());
            SaveManager.SaveUserData(userData);
        }

    }

    public static void StartGame()
    {
        Debug.Log("StartGame now");
    }

    public static void SeeLeaderboard()
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

    public static void ExitGame()
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
        uiManager.ShowUI();
    }
}
