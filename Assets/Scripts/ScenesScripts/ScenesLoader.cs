using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesLoader
{
    public enum Scenes
    {
        GameScene,
        MenuScene,
        HelpScene
    }

    public static void Load(Scenes scenes)
    {
        SceneManager.LoadScene(scenes.ToString());
    }
}
