using System;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class PlayerController : MonoBehaviour
    {

        [Header("Prefabs")]
        [SerializeField] private PlatformController _playerPlatform;
        [SerializeField] private BallController _playerBall;
        [Header("Game Object")]
        [SerializeField] private GameObject _playerParent;
        [Header("Main Camera For Platform")]
        [SerializeField] private Camera _mainCamera;

        private PlatformController _currentPlatform;
        private BallController _currentBall;

        private void OnEnable()
        {
            SelectStageWindow.LevelStarted += StartWindowOnLevelStarted;
        }

        private void OnDisable()
        {
            SelectStageWindow.LevelStarted -= StartWindowOnLevelStarted;
        }

        private void StartWindowOnLevelStarted()
        {
            CreateBall();
            CreatePlatform(_mainCamera);
        }

        public void CreatePlatform(Camera mainCamera) 
        {
            if (_currentPlatform)
            { 
                Destroy(_currentPlatform);
            }

            _currentPlatform = Instantiate(_playerPlatform, _playerParent.transform);
            _currentPlatform.MainCamera = _mainCamera;
        }
        
        public void CreateBall() 
        {
            if (_currentBall)
            { 
                Destroy(_currentBall);
            }

            _currentBall = Instantiate(_playerBall);
        }

        public void DestroyPlatform() 
        {
            Destroy(_currentPlatform);
        }
        
        public void DestroyBall() 
        {
            Destroy(_currentBall);
        }
    }
}
