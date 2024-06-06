using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Arkanoid
{
    public class LevelController : MonoBehaviour
    {
        //public static LevelController Instance;

        //public void Init()
        //{
        //    if (Instance == null)
        //    {
        //        Instance = this;
        //    }
        //}

        public static event Action<int> ScoreChanged;
        public static event Action<int> LifesChanged;
        public static event Action<int> LifesSetted;

        //[SerializeField] private GameObject _gameContent;
        [Min(3)]
        [SerializeField] private int _lifesOnStart;

        private int _score;
        private int _lifes;

        private void Awake()
        {
            //_gameContent.SetActive(false);
        }

        private void OnEnable()
        {
            SelectStageWindow.LevelStarted += StartWindowOnLevelStarted;
            DestroyableBlock.Destroyed += DestroyableBlockOnDestroyed;
            FailedLevelTrigger.LevelFailed += LevelFailed;
            FailPopup.RestartedLevel += FailPopupOnRestartedLevel;
            FailPopup.QuitedLevel += FailPopupOnQuitedLevel;
            PausePopup.QuitedLevel += PausePopupOnQuitedLevel;
        }

        private void OnDisable()
        {
            SelectStageWindow.LevelStarted -= StartWindowOnLevelStarted;
            DestroyableBlock.Destroyed -= DestroyableBlockOnDestroyed;
            FailedLevelTrigger.LevelFailed -= LevelFailed;
            FailPopup.RestartedLevel -= FailPopupOnRestartedLevel;
            FailPopup.QuitedLevel -= FailPopupOnQuitedLevel;
            PausePopup.QuitedLevel -= PausePopupOnQuitedLevel;
        }

        private void StartWindowOnLevelStarted()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);

            _lifes = _lifesOnStart;
            LifesSetted?.Invoke(_lifes);

            //_gameContent.SetActive(true);
        }

        private void DestroyableBlockOnDestroyed(int blockHitPoints)
        {
            _score += blockHitPoints;
            ScoreChanged?.Invoke(_score);
        }

        public void LevelFailed()
        {
            _lifes--;
            LifesChanged?.Invoke(_lifes);

            if (_lifes <= 0)
            {
                UISystem.Instance.OpenWindow(WindowType.Fail, true);
                //_gameContent.SetActive(false);
            }
        }

        private void FailPopupOnRestartedLevel()
        {
            LevelLoader.Instance.ReloadLevel();
            StartWindowOnLevelStarted();
            UISystem.Instance.OpenWindow(WindowType.Game, false);
        }

        private void FailPopupOnQuitedLevel()
        {
            LevelLoader.Instance.HideLevel();
            UISystem.Instance.OpenWindow(WindowType.Start, false);
        }

        private void PausePopupOnQuitedLevel()
        {
            LevelLoader.Instance.HideLevel();
            UISystem.Instance.OpenWindow(WindowType.SelectStage, false);
        }
    }
}