//using System;
//using UnityEngine;


//namespace Assets.Scripts.Arkanoid
//{
//    public class LevelLoader : MonoBehaviour
//    {
//        public static event Action LevelClosed;
//        public static event Action LevelLoaded;

//        [SerializeField] private Transform _levelParent;

//        public static LevelLoader Instance;

//        private GameObject _currentLevel;
//        private LevelSettings _levelSettings;

//        public GameObject CurrentLevel => _currentLevel;


//        public void Init()
//        {
//            if (Instance == null)
//            {
//                Instance = this;
//            }
//        }

//        public void LoadLevel(int levelIndex)
//        {
//            if (_currentLevel)
//            {
//                Destroy(_currentLevel);
//                LevelClosed?.Invoke();
//            }

//            _currentLevel = Instantiate(_levelSettings.Levels[levelIndex], _levelParent);
//            LevelLoaded?.Invoke();
//        }

//        public void HideLevel()
//        {
//            _currentLevel.SetActive(false);

//            LevelClosed?.Invoke();
//        }

//    }
//}