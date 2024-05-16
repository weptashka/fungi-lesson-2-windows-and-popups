using UnityEngine;
using System;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Arkanoid
{
    public class LevelController : MonoBehaviour
    {
        public static event Action<int> ScoreChanged;
        public static event Action<int> LifesChanged;
        public static event Action<int> LifesSetted;


        [SerializeField] private GameObject _gameContent;
        [Min(1)]
        [SerializeField] private int _lifes;

        private int _score;


        private void Awake()
        {
            _gameContent.SetActive(false);
        }

        private void OnEnable()
        {
            SelectStageWindow.LevelStarted += StartWindowOnLevelStarted;
            DestroyableBlock.Destroyed += DestroyableBlockOnDestroyed;
            FailedLevelTrigger.LevelFailed += LevelFailed;
            FailPopup.RestartedLevel += FailPopupOnRestartedLevel;
            FailPopup.QuitedLevel += FailPopupOnQuitedLevel;
            PausePopup.QuitedLevel += PausePopupOnQuitedLevel;
            GameWindow.PausedGame += PausePopupOnPausedGame;
            PausePopup.StartedGame += PausePopupOnStartedGame;
        }

        private void OnDisable()
        {
            SelectStageWindow.LevelStarted -= StartWindowOnLevelStarted;
            DestroyableBlock.Destroyed -= DestroyableBlockOnDestroyed;
            FailedLevelTrigger.LevelFailed -= LevelFailed;
            FailPopup.RestartedLevel -= FailPopupOnRestartedLevel;
            FailPopup.QuitedLevel -= FailPopupOnQuitedLevel;
            PausePopup.QuitedLevel -= PausePopupOnQuitedLevel;
            GameWindow.PausedGame -= PausePopupOnPausedGame;
            PausePopup.StartedGame -= PausePopupOnStartedGame;
        }

        private void StartWindowOnLevelStarted()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);

            LifesSetted?.Invoke(_lifes);

            _gameContent.SetActive(true);
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
                _gameContent.SetActive(false);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void FailPopupOnRestartedLevel()
        {
            //???
            UISystem.Instance.Close(WindowType.Fail);
            UISystem.Instance.OpenWindow(WindowType.Game, false);
            SceneManager.LoadScene("GameScene");
            //потому что не из SelectStage выбираем уровень, приходится самим вызывать
            StartWindowOnLevelStarted();
            Debug.Log("RESTART");
        }

        private void FailPopupOnQuitedLevel()
        {
            SceneManager.LoadScene("GameScene");
            UISystem.Instance.OpenWindow(WindowType.Start, false);
            Debug.Log("QUIT");
        }

        private void PausePopupOnQuitedLevel()
        {
            SceneManager.LoadScene("GameScene");
            UISystem.Instance.OpenWindow(WindowType.SelectStage, false);
            Debug.Log("QUIT TO LEVELS FROM PAUSE");
        }
        
        private void PausePopupOnPausedGame()
        {
            UISystem.Instance.OpenWindow(WindowType.Pause, true);
            Debug.Log("PAUSE");
        }

        private void PausePopupOnStartedGame()
        {
            UISystem.Instance.Close(WindowType.Pause);
            Debug.Log("UNPAUSE");
        }
    }
}