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

        private int _levelIndex;
        private Action _callBack;

        private void Start()
        {
            _levelButton.onClick.AddListener(OnLevelButtonClick);
        }

        public void Setup(int levelIndex, Action callBack)
        {
            _levelIndex = levelIndex;
            _levelIndexText.text = (levelIndex + 1).ToString();
            _callBack = callBack;
        }

        private void OnLevelButtonClick()
        {
            _callBack?.Invoke();
            LevelLoader.Instance.LoadLevel(_levelIndex);
        }
    }
}
