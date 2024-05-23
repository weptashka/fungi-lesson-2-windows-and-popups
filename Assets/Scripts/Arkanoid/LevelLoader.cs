using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Arkanoid
{
    public class LevelLoader : MonoBehaviour
    {
        public static event Action LevelClosed;
        public static event Action LevelLoaded;

        public static LevelLoader Instance;

        private readonly string _scenesPath = "Assets/Scenes/";

        [SerializeField] private Transform _levelParent;

        private GameObject _currentLevel;
        public GameObject CurrentLevel => _currentLevel;

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

        public void LoadLevel(int levelIndex)
        {
            if (_currentLevel)
            {
                Destroy(_currentLevel);
                LevelClosed?.Invoke();
            }

            _currentLevel = Instantiate(SettingsManager.Instance.LevelSettings.LevelPrefabs[levelIndex], _levelParent);
            LevelLoaded?.Invoke();
        }

        public void HideLevel()
        {
            _currentLevel.SetActive(false);

            LevelClosed?.Invoke();
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