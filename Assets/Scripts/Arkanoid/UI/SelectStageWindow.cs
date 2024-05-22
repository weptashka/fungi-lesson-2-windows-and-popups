using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Arkanoid;

namespace Assets.Scripts
{
    public class SelectStageWindow : WindowBase
    {
        public static event Action LevelStarted;

        [SerializeField] private Button _backButton;
        [SerializeField] private SelectLevelCeil _ceilPrefab;
        [SerializeField] private Transform _ceilParent;

        public override WindowType Type => WindowType.SelectStage;
        public override bool IsPopup => false;

        private void Start()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);

            var levelSettingsLevelNames = SettingsManager.Instance.LevelSettings.LevelNames;

            for (int i = 0; i < levelSettingsLevelNames.Length; i++)
            { 
                SelectLevelCeil selectLevelSeil = Instantiate(_ceilPrefab, _ceilParent);

                selectLevelSeil.Setup(i, OnCeilClicked);
            }
        }

        private void OnCeilClicked()
        {
            UISystem.Instance.OpenWindow(WindowType.Game, false);
            LevelStarted?.Invoke();
        }

        private void OnBackButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Start, true);
        }
    }
}
