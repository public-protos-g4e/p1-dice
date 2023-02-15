using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private UIManager uim;

    [SerializeField]
    private UIDocument maiMenu;
    private VisualElement root;
    private Button startButton;
    private Button leaderboardButton;
    private Button exitButton;

    // @todo Move all this UI Behaviour to a UIManager Class
    void Awake()
    {
        root = maiMenu.rootVisualElement;
        
        startButton       = root.Q<Button>("StartButton");
        leaderboardButton = root.Q<Button>("LeaderboardButton");
        exitButton        = root.Q<Button>("ExitButton");
    }

    void Start()
    {
        SetUIButtonsAction();
    }

    public void SetUIButtonsAction()
    {
        if(startButton != null) {
            startButton.clickable.clicked += StartGame;
        }
        
        if(leaderboardButton != null) {
            leaderboardButton.clickable.clicked += SeeLeaderboard;
        }

        if(exitButton != null) {
            exitButton.clickable.clicked += ExitGame;
        }
    }

    public void StartGame()
    {
        Debug.Log("StartGame now");
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
    }
}
