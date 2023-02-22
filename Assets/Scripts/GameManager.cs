using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    void Start()
    {
        // ...
    }

    public static void StartGame()
    {
        Debug.Log("StartGame now");
    }

    public static void SeeLeaderboard()
    {
        Debug.Log("SeeLeaderboard now");
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
