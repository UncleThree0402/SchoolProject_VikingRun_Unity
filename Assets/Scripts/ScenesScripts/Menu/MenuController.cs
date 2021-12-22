using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class MenuController : MonoBehaviour
{
    public Button startButton;
    public Button helpButton;
    public Button exitButton;

    public VisualElement menu;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("Start");
        helpButton = root.Q<Button>("Help");
        exitButton = root.Q<Button>("Exit");
        menu = root.Q<VisualElement>("ButtonBack");

        startButton.clicked += startPress;
        helpButton.clicked += helpPress;
        exitButton.clicked += exitPress;
    }

    private void startPress()
    {
        menu.style.display = DisplayStyle.None;
        ScenesLoader.Load(ScenesLoader.Scenes.GameScene);
    }
    
    private void helpPress()
    {
        menu.style.display = DisplayStyle.None;
        ScenesLoader.Load(ScenesLoader.Scenes.HelpScene);
    }

    private void exitPress()
    {
        Application.Quit();
    }
}
