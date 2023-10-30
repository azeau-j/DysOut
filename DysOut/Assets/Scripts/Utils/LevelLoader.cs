using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dys_The_Game.Utils
{
    public class LevelLoader : MonoBehaviour
    {
        enum MainScenes
        {
            MainMenu,
            Map
        }

        private const string MAIN_MENU_SCENE_NAME = "MainMenu";
        private const string MAP_SCENE_NAME = "Map";

        [SerializeField] private MainScenes _levelToLoad;

        public void LoadScene()
        {
            SceneManager.LoadScene(GetSceneName());
        }

        private string GetSceneName()
        {            
            switch (_levelToLoad) {
                case MainScenes.MainMenu:
                    return MAIN_MENU_SCENE_NAME;
                case MainScenes.Map:
                    return MAP_SCENE_NAME;
            }
            
            return null;
        }
    }
}
