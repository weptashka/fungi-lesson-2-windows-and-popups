using System;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class PlayerController : MonoBehaviour
    {

        [Header("Prefabs")]
        [SerializeField] private PlatformController _playerPlatformPrefab;
        [SerializeField] private BallController _playerBallPrefab;
        [Header("Game Object")]
        [SerializeField] private GameObject _playerParent;
        [Header("Main Camera For Platform")]
        [SerializeField] private Camera _mainCamera;

        public PlatformController _currentPlatform;
        public BallController _currentBall;

        private void OnEnable()
        {
            LevelLoader.LevelLoaded += StartWindowOnLevelStarted;
            LevelLoader.LevelClosed += LevelLoader_LevelClosed;
        }

        private void LevelLoader_LevelClosed()
        {
            DestroyPlatform();
            DestroyBall();
        }

        private void OnDisable()
        {
            LevelLoader.LevelLoaded -= StartWindowOnLevelStarted;
            LevelLoader.LevelClosed -= LevelLoader_LevelClosed;

        }

        private void StartWindowOnLevelStarted()
        {
            CreatePlatform(_mainCamera);
            CreateBall();
        }

        public void CreatePlatform(Camera mainCamera) 
        {
            if (_currentPlatform)
            { 
                Destroy(_currentPlatform);
            }

            _currentPlatform = Instantiate(_playerPlatformPrefab, _playerParent.transform);
            _currentPlatform.MainCamera = _mainCamera;
        }
        
        public void CreateBall() 
        {
            if (_currentBall)
            { 
                Destroy(_currentBall);
            }

            _currentBall = Instantiate(_playerBallPrefab, _currentPlatform.BallInitPoint);
        }

        public void DestroyPlatform() 
        {
            if (_currentPlatform != null)
            {
                Destroy(_currentPlatform.gameObject);
            }
        }
        
        public void DestroyBall() 
        {
            if (_currentBall != null)
            {
                Destroy(_currentBall.gameObject);
            }
        }
    }
}
