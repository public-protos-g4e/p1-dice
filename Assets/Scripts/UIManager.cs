using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenu;

    public Button startButton;
    public Button leaderboardButton;
    public Button exitButton;

    public void Start()
    {
        startButton       = mainMenu.rootVisualElement.Q<Button>("StartButton");
        leaderboardButton = mainMenu.rootVisualElement.Q<Button>("LeaderboardButton");
        exitButton        = mainMenu.rootVisualElement.Q<Button>("ExitButton");

        AddMainMenuButtonEvents();
    }

    public void AddMainMenuButtonEvents()
    {
        startButton.clickable.clicked += GameManager.StartGame;
        leaderboardButton.clickable.clicked += GameManager.SeeLeaderboard;
        exitButton.clickable.clicked += GameManager.ExitGame;
    }

    public void HideUI()
    {
        mainMenu.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowUI()
    {
        mainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
