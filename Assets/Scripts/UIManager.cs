using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenu;
    [SerializeField] private UIDocument inGame;
    [SerializeField] private UIDocument messageText;

    private Button startButton;
    private Button leaderboardButton;
    private Button exitButton;
    
    private Label messagesMainText;
    private Label messagesSecondaryText;
    private Button messagesBackToMainMenu;
    
    private Label scoreText;

    public void Start()
    {
        // Main menu
        startButton       = mainMenu.rootVisualElement.Q<Button>("StartButton");
        leaderboardButton = mainMenu.rootVisualElement.Q<Button>("LeaderboardButton");
        exitButton        = mainMenu.rootVisualElement.Q<Button>("ExitButton");
        AddMainMenuButtonEvents();

        // Game Over, warnings or wherever messages
        messagesMainText = messageText.rootVisualElement.Q<Label>("MainText");
        messagesSecondaryText = messageText.rootVisualElement.Q<Label>("SecondaryText");
        messagesBackToMainMenu = messageText.rootVisualElement.Q<Button>("BackToMainMenuButton");

        // In Game
        scoreText = inGame.rootVisualElement.Q<Label>("ScoreText");
    }

    public void AddMainMenuButtonEvents()
    {
        startButton.clickable.clicked += GameManager.Instance.StartGame;
        leaderboardButton.clickable.clicked += GameManager.Instance.SeeLeaderboard;
        exitButton.clickable.clicked += GameManager.Instance.ExitGame;
    }

    public void HideMainMenu()
    {
        mainMenu.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowMainMenu()
    {
        mainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void HideIngameUI()
    {
        inGame.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowIngameUI()
    {
        inGame.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void HideMessageText()
    {
        messageText.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowMessageText()
    {
        messageText.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void SetScore(int scoreText)
    {
        this.scoreText.text = "Current score: " + scoreText;
    }

    public void setMessagesMainText(string text)
    {
        this.messagesMainText.text = text;
    }

    public void setMessagesSecondaryText(string text)
    {
        this.messagesSecondaryText.text = text;
    }

    public Button GetMessageButton()
    {
        return messagesBackToMainMenu;
    }

}
