
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class StartWindow : WindowBase
    {
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
            UISystem.Instance.OpenWindow(WindowType.SelectStage, false);
        }
        
        private void OnSettingsButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Settings, true);
        }
    }
}
