using System;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class StartWindow : WindowBase
    {
        public static event Action LevelStarted;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;


        public override WindowType Type => WindowType.Start;
        public override bool IsPopup => false;


        public void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnStartButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Game, false);

            if (LevelStarted != null)
            {
                LevelStarted.Invoke();
                Debug.Log("INVOKED");
            }
            else 
            {
                Debug.Log("LevelStarted IS NULL");
            }

            LevelStarted?.Invoke();
        }
        
        private void OnSettingsButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Settings, true);
        }
    }
}
