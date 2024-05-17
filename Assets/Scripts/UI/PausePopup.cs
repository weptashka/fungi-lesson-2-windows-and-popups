using System;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Arkanoid
{
    public class PausePopup : WindowBase
    {
        public static event Action QuitedLevel;

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
            UISystem.Instance.Close(WindowType.Pause); 
        }

        private void OnClikQuitButton()
        {
            QuitedLevel?.Invoke();
        }
    }
}