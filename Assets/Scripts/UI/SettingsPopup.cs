using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SettingsPopup : WindowBase
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;

        public override WindowType Type => WindowType.Settings;
        public override bool IsPopup => true;

        private void Start()
        {
            _backButton.onClick.AddListener(OnClikBackButton);
        }

        private void OnClikBackButton()
        {
            UISystem.Instance.Close(Type);
        }
    }
}
