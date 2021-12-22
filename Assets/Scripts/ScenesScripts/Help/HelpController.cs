using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScenesScripts.Help
{
    public class HelpController : MonoBehaviour
    {
        private Button back;


        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            back = root.Q<Button>("Back");

            back.clicked += OnBack;
        }

        private void OnBack()
        {
            ScenesLoader.Load(ScenesLoader.Scenes.MenuScene);
        }
    }
}