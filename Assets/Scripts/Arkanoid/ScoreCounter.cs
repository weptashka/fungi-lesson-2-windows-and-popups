using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _blocks;
        [SerializeField] private DestroyableBlock[] _destroyableBlocks;

        private int _allPoints = 0;
        private int _remainPoints = 0;
        private int _currentBlocksCount;



        private void Start()
        {
            _destroyableBlocks = _blocks.GetComponentsInChildren<DestroyableBlock>();
            _currentBlocksCount = _destroyableBlocks.Length;

            foreach (DestroyableBlock dblock in _destroyableBlocks)
            {
                _allPoints += dblock.GetHitPoints();   
            }

            Debug.Log($"ALL POINTS: \n{_allPoints}");
        }


        private void Update()
        {
            _destroyableBlocks = _blocks.GetComponentsInChildren<DestroyableBlock>();
            var _newBlocksCount = _destroyableBlocks.Length;

            if (_newBlocksCount < _currentBlocksCount)
            {
                _remainPoints = 0;

                foreach (DestroyableBlock dblock in _destroyableBlocks)
                {
                    _remainPoints += dblock.GetHitPoints();
                }

                Debug.Log($"REMAINING HIT POINTS: \n{_remainPoints}");
                _scoreText.text = $"Score:\n{_allPoints - _remainPoints}";

                _currentBlocksCount = _newBlocksCount;
            }
        }

    }
}
