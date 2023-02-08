using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    /*
     * Last Score
     * Max Score
     * Player Name
     * Scoreboard : json { "name": "score" }
     */
    // game constants
    private const string LAST_SCORE_KEY = "last_score";
    private const string MAX_SCORE_KEY = "max_score";
    private const string PLAYER_NAME_KEY = "player_name";
    private const string SCOREBOARD_KEY = "scoreboard";
    
    //Getters 
    public static int GetLastScore()
    {
        return PlayerPrefs.GetInt(LAST_SCORE_KEY, 0);
    }
    
    public static int GetMaxScore()
    {
        return PlayerPrefs.GetInt(MAX_SCORE_KEY, 0);
    }
    
    public static string GetPlayerName()
    {
        return PlayerPrefs.GetString(PLAYER_NAME_KEY, "Player");
    }
    
    public static string GetScoreboard()
    {
        return PlayerPrefs.GetString(SCOREBOARD_KEY, "{}");
    }
    // Setters
    public static void SetLastScore(int score)
    {
        PlayerPrefs.SetInt(LAST_SCORE_KEY, score);
    }
    
    public static void SetMaxScore(int score)
    {
        PlayerPrefs.SetInt(MAX_SCORE_KEY, score);
    }
    
    public static void SetPlayerName(string name)
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, name);
    }
    
    public static void SetScoreboard(string scoreboard)
    {
        PlayerPrefs.SetString(SCOREBOARD_KEY, scoreboard);
    }
    
    public static void UpdateScoreboard(string name, int score)
    {
        // get the scoreboard
        string scoreboard = GetScoreboard();
        // convert it to a dictionary
        Dictionary <string, int> scoreboardDict = JsonUtility.FromJson<Dictionary<string, int>>(scoreboard);
        // add the new score
        scoreboardDict.Add(name, score);
        // convert it back to json
        scoreboard = JsonUtility.ToJson(scoreboardDict);
        // save it
        SetScoreboard(scoreboard);
    }

}