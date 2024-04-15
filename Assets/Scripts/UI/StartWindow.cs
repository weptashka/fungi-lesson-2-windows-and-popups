using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class StartWindow : WindowBase
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private WindowType _startButtonPath;
        [Space]
        [SerializeField] private Button _settingsButton;
        [SerializeField] private WindowType _settingsButtonPath;

        public override WindowType Type => WindowType.Start;
        public override bool IsPopup => false;

        public void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnStartButtonClick()
        {
            UISystem.Instance.OpenWindow(_startButtonPath, false);
        }
        
        private void OnSettingsButtonClick()
        {
            UISystem.Instance.OpenWindow(_settingsButtonPath, true);
        }
    }
}
