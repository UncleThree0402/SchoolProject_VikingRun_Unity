using System.Collections;
using System.Collections.Generic;
using Controller;
using Interface;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSceneController : MonoBehaviour, IObserver
{
    private Label scroceText;
    private Label timeText;
    private Label scroceDieText;
    private Label timeDieText;
    
    private Button backButton;
    private Button menuButton;

    private VisualElement onPlayElement;
    private VisualElement onDieElement;
    void Start()
    {
        FindObjectOfType<PlayerStatController>().Attach(this);
        var root = GetComponent<UIDocument>().rootVisualElement;
        scroceText = root.Q<Label>("Scores");
        timeText = root.Q<Label>("Time");
        scroceDieText = root.Q<Label>("ScoresEnd");
        timeDieText = root.Q<Label>("TimeEnd");
        backButton = root.Q<Button>("Back");
        menuButton = root.Q<Button>("Menu");
        onPlayElement = root.Q<VisualElement>("BackGround");
        onDieElement = root.Q<VisualElement>("OnDieBackGround");

        backButton.clicked += OnBack;
        menuButton.clicked += OnBack;
    }

    private void OnBack()
    {
        onPlayElement.style.display = DisplayStyle.None;
        onDieElement.style.display = DisplayStyle.None;
        ScenesLoader.Load(ScenesLoader.Scenes.MenuScene);
    }

    public void OnDie()
    {
        onPlayElement.style.display = DisplayStyle.None;
        onDieElement.style.display = DisplayStyle.Flex;
    }
    
    
    public void UpdateData(IObservable observable)
    {
        if (observable is PlayerStatsModel playerStatsModel)
        {
            scroceText.text = ((int) playerStatsModel.Scores).ToString();
            timeText.text = ((int) playerStatsModel.Time).ToString();
            scroceDieText.text = "Scores : " + ((int) playerStatsModel.Scores).ToString();
            timeDieText.text = "Time : " + ((int) playerStatsModel.Time).ToString();
        }
    }
}
