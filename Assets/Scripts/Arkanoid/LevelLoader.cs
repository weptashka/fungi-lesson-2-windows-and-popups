using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Arkanoid
{
    public class LevelLoader : MonoBehaviour
    {
        private readonly string _scenesPath = "Assets/Scenes/";

        public static LevelLoader Instance;

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(_scenesPath + sceneName + ".unity");
        }


        //public static event Action LevelClosed;
        //public static event Action LevelLoaded;

        //[SerializeField] private Transform _levelParent;



        //private GameObject _currentLevel;
        //private LevelSettings _levelSettings;

        //public GameObject CurrentLevel => _currentLevel;



        //public void LoadLevel(int levelIndex)
        //{
        //    if (_currentLevel)
        //    {
        //        Destroy(_currentLevel);
        //        LevelClosed?.Invoke();
        //    }

        //    _currentLevel = Instantiate(_levelSettings.Levels[levelIndex], _levelParent);
        //    LevelLoaded?.Invoke();
        //}

        //public void HideLevel()
        //{
        //    _currentLevel.SetActive(false);

        //    LevelClosed?.Invoke();
        //}

    }
}