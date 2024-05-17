﻿using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class GameWindow : WindowBase
    {
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
            UISystem.Instance.OpenWindow(WindowType.Pause, true);
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
            base.Close();

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
            foreach (Transform life in _lifesImagesParent.transform)
            {
                Destroy(life.gameObject);
            }

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

