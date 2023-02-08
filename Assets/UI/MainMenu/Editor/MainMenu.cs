using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

public class MainMenu : EditorWindow
{
    private VisualElement container;
    public const string path = "Assets/UI/MainMenu/Editor/";

    [MenuItem("ChiriDice/Main menu")]
    public static void ShowWindow()
    {
        MainMenu window = GetWindow<MainMenu>();
        window.titleContent = new GUIContent("Main menu");
        window.minSize = new Vector2(300, 400);
    }

    public void CreateGUI()
    {
        this.container = rootVisualElement;

        // Load uxml file
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path + "MainMenu.uxml");
        this.container.Add(visualTree.Instantiate());

        // Load uss file
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(path + "MainMenu.uss");
        this.container.styleSheets.Add(styleSheet);
    }
}
