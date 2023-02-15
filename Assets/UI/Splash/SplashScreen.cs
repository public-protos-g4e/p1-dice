using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

public class Splash : EditorWindow
{
    VisualElement container;

    public static void ShowWindow()
    {
        Splash window = GetWindow<Splash>();
        window.titleContent = new GUIContent("UISplash");
    }
    
    public void CreateGUI()
    {
        this.container = rootVisualElement;
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Splash/Editor/SplashScreen.uxml");
        this.container.Add(visualTree.Instantiate());

        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/Splash/Editor/SplashScreen.uss");
        this.container.styleSheets.Add(styleSheet);
    }
}
