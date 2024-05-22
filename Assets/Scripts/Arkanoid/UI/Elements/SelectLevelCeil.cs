using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Arkanoid
{
    public class SelectLevelCeil : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelIndexText;
        [SerializeField] private Button _levelButton;

        private int _sceneIndex;
        private Action _callBack;

        private void Start()
        {
            _levelButton.onClick.AddListener(OnLevelButtonClick);
        }

        public void Setup(int sceneIndex, Action callBack)
        {
            _sceneIndex = sceneIndex;
            _levelIndexText.text = (sceneIndex + 1).ToString();
            _callBack = callBack;
        }

        private void OnLevelButtonClick()
        {
            LevelLoader.Instance.LoadScene(_sceneIndex + 1);
            UISystem.Instance.OpenWindow(WindowType.Game, false);
            _callBack?.Invoke();
        }
    }
}
