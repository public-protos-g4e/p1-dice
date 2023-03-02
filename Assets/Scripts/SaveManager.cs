using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class UserScore
{
    public string Name { get; set; }
    public int Score { get; set;}
}
public class UserData
{
    public string Username { get; set; }
    public int LastScore { get; set; }
    public List<UserScore> Leaderboard { get; set; }
    public UserData(string username, int lastScore, List<UserScore> leaderboard)
    {
        Username = username;
        LastScore = lastScore;
        Leaderboard = leaderboard;
    }
}

public static class SaveManager
{
    private const string FileName = "userdata.json";
    
    public static UserData LoadUserData()
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<UserData>(json);
        }
        else
        {
            return null;
        }
    }
    public static void SaveUserData(UserData data)
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(path, json);
    }
    
    public static void AddScoreToLeaderboard(UserData userData, string newName, int newScore)
    {
        UserScore userScore = new UserScore();
        userScore.Name = newName;
        userScore.Score = newScore;
        userData.Leaderboard.Add(userScore);
        userData.Leaderboard = OrderPlayersByScore(userData.Leaderboard);
        SaveUserData(userData);
    }
    public static List<UserScore> OrderPlayersByScore(List<UserScore> leaderboard)
    {
        return leaderboard.OrderByDescending(x => x.Score).ToList();
    }
}