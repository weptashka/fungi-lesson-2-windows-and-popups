using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SelectStageWindow : WindowBase
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private WindowType _windowType;

        public override WindowType Type => WindowType.SelectStage;
        public override bool IsPopup => false;

        private void Start()
        {
            _backButton.onClick.AddListener(OnClikBackButton);

        }

        private void OnClikBackButton()
        {
            UISystem.Instance.OpenWindow(_windowType, true);
        }
    }
}
