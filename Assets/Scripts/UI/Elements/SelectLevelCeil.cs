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

        private string _sceneName;
        private Action _callBack;

        private void Start()
        {
            _levelButton.onClick.AddListener(OnLevelButtonClick);
        }

        public void Setup(string sceneName, int sceneIndex, Action callBack)
        {
            _sceneName = sceneName;
            _levelIndexText.text = sceneIndex.ToString();
            _callBack = callBack;
        }

        private void OnLevelButtonClick()
        {
            LevelLoader.Instance.LoadScene(_sceneName);
            UISystem.Instance.OpenWindow(WindowType.Game, false);
            _callBack?.Invoke();
        }
    }
}
