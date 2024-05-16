using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class GameWindow : WindowBase
    {
        public static event Action PausedGame;

        [SerializeField] TMP_Text _scoreText;
        [SerializeField] TMP_Text _lifesText;
        [SerializeField] GameObject _lifesImagePrefab;
        [SerializeField] GameObject _lifesImagesParent;
        [SerializeField] Button _pauseButton;


        public override WindowType Type => WindowType.Game;
        public override bool IsPopup => false;

        public void Start()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            PausedGame?.Invoke();
        }

        public override void Open()
        {
            base.Open();
            LevelController.ScoreChanged += LevelControllerOnScoreChanged;
            LevelController.LifesChanged += LevelControllerOnLifesChanged;
            LevelController.LifesSetted += LevelControllerOnLifesSetted;
        }

        public override void Close()
        {
            base.Open();
            LevelController.ScoreChanged -= LevelControllerOnScoreChanged;
            LevelController.LifesChanged -= LevelControllerOnLifesChanged;
            LevelController.LifesSetted -= LevelControllerOnLifesSetted;
        }

        private void LevelControllerOnScoreChanged(int currentScore)
        {
            _scoreText.text = $"SCORE: {currentScore}";
        }

        private void LevelControllerOnLifesSetted(int allLifes)
        {
            for (int i = 0; i < allLifes; i++)
            {
                Instantiate(_lifesImagePrefab, _lifesImagesParent.transform);
            }
        }

        private void LevelControllerOnLifesChanged(int currentLifes)
        {
            _lifesText.text = $"LIFES: {currentLifes}";

            _lifesImagesParent.transform.GetChild(currentLifes).gameObject.SetActive(false);
        }
    }
}

