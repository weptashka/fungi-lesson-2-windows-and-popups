using System;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Arkanoid
{
    public class PausePopup : WindowBase
    {
        public static event Action QuitedLevel;
        public static event Action StartedGame;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;


        public override WindowType Type => WindowType.Pause;
        public override bool IsPopup => true;


        private void Start()
        {
            _playButton.onClick.AddListener(OnClikPlayButton);
            _quitButton.onClick.AddListener(OnClikQuitButton);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        private void OnClikPlayButton()
        {
            StartedGame?.Invoke();
        }

        private void OnClikQuitButton()
        {
            QuitedLevel?.Invoke();
        }
    }
}