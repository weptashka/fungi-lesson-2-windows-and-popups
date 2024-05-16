using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SelectStageWindow : WindowBase
    {
        public static event Action LevelStarted;

        [SerializeField] private Button _levelButton;
        [SerializeField] private Button _backButton;

        public override WindowType Type => WindowType.SelectStage;
        public override bool IsPopup => false;

        private void Start()
        {
            _backButton.onClick.AddListener(OnBackButtonClik);
            _levelButton.onClick.AddListener(OnLevelButtonClik);
        }

        private void OnBackButtonClik()
        {
            UISystem.Instance.OpenWindow(WindowType.Start, true);
        }

        private void OnLevelButtonClik()
        {
            UISystem.Instance.OpenWindow(WindowType.Game, false);
            LevelStarted?.Invoke();
        }
    }
}
