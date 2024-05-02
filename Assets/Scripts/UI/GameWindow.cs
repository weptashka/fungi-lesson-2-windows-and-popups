using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameWindow : WindowBase
    {
        [SerializeField] TMP_Text _scoreText;

        public override WindowType Type => WindowType.Game;
        public override bool IsPopup => false;


        public override void Open()
        {
            base.Open();

            LevelController.ScoreChanged += LevelControllerOnScoreChanged;
        }

        private void LevelControllerOnScoreChanged(int currentScore)
        {
            _scoreText.text = $"Score:\n{currentScore}";
        }
    }
}

