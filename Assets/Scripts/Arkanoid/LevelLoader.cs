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


        private int _currentLevelIndex = -1;

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

            _currentLevelIndex = levelIndex;
        }

        public void ReloadLevel()
        {
            if (_currentLevelIndex == -1)
            {
                return;
            }

            if (_currentLevel)
            {
                Destroy(_currentLevel);
                LevelClosed?.Invoke();
            }

            _currentLevel = Instantiate(SettingsManager.Instance.LevelSettings.LevelPrefabs[_currentLevelIndex], _levelParent);
            LevelLoaded?.Invoke();
        }

        public void HideLevel()
        {
            _currentLevel.SetActive(false);

            LevelClosed?.Invoke();
        }

    }
}