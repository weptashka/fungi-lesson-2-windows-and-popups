using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LevelFailedPopup : WindowBase
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;


        public override WindowType Type => WindowType.Fail;
        public override bool IsPopup => true;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnClikRestartButton);
            _restartButton.onClick.AddListener(OnClikQuitButton);
        }

        private void OnClikRestartButton()
        {

        }
        
        
        private void OnClikQuitButton()
        {

        }
    }
}
