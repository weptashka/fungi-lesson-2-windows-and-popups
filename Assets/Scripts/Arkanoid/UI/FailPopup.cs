using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class FailPopup : WindowBase
    {
        public static event Action RestartedLevel; 
        public static event Action QuitedLevel; 

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        public override WindowType Type => WindowType.Fail;
        public override bool IsPopup => true;

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        private void Start()
        {
            _restartButton.onClick.AddListener(OnClikRestartButton);
            _quitButton.onClick.AddListener(OnClikQuitButton);
        }

        private void OnClikRestartButton()
        {
            RestartedLevel?.Invoke();
        }
        
        private void OnClikQuitButton()
        {
            QuitedLevel?.Invoke();
        }
    }
}
