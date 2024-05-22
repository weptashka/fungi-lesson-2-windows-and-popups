using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Arkanoid 
{
    public class PickableController : MonoBehaviour
    {
        [SerializeField] private Transform _blockParent;
        [Header("Create pickable intensivity")]
        [SerializeField] private int _minRange;
        [SerializeField] private int _maxRange;
        [Space]
        [SerializeField] private BonusBase[] _bonuses;

        private DestroyableBlock[] _destroyableBlock;
        private int _destroyBlockCount;
        private int _range = -1;
        private float[] _bonusesIntensivity;

        private bool _bigBall = false;
        private bool _platformEnlarge = false;

        private int _touchesAfterEnlarge = 0;
        private int _touchesAfterShorten = 0;
        private int _touchesAfterBigBall = 0;

        private void Awake()
        {
            _destroyableBlock = _blockParent.GetComponentsInChildren<DestroyableBlock>();

            foreach (var block in _destroyableBlock)
            {
                if (block.IsGeneratesBonus)
                {
                    block.Setup(this);
                }
            }

            _bonusesIntensivity = new float[_bonuses.Length];

            IntensivityInProcentCount();
        }

        private void OnEnable()
        {
            BonusBase.BonusPicked += BonusBaseOnBonusPicked;
            PlatformController.BallTochedPlatform += PlatformControllerOnBallTochedPlatform;
        }

        private void BonusBaseOnBonusPicked(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.Enlarge:
                    _touchesAfterEnlarge = 0;
                    break;
                case BonusType.Shorten:
                    _touchesAfterShorten = 0;
                    break;
                case BonusType.BigBall:
                    _touchesAfterBigBall = 0;
                    break;
            }
        }

        private void PlatformControllerOnBallTochedPlatform()
        {
            _touchesAfterEnlarge++;
            _touchesAfterShorten++;
            _touchesAfterBigBall++;
        }

        public void OnBlockDestroyed(Vector3 position)
        {
            //тут забабахать интесивность (вероятность) выпадения впринципи любого бонуса
            //(частота выпадения бонусов)
            _destroyBlockCount++;

            if (_range < 0)
            {
                var range = Random.Range(_minRange, _maxRange);
            }

            if (_destroyBlockCount >= _range)
            {
                _range = -1;
                _destroyBlockCount = 0;
                CreatePickable(position);
            }
        }

        private void CreatePickable(Vector3 position)
        {
            //процентная вероятность выпадения с учётом тОго, что каждому бонусу
            //можно поставить интенсивность от 0 до 100
            float rand = Random.Range(0f, 100f);

            Debug.Log($"RAND = {rand}");

            float temp = 0; ;
            int minIndex = 0;

            for (int i = 0; i < _bonusesIntensivity.Length; i++)
            {
                temp += _bonusesIntensivity[i];

                if (temp > rand)
                {
                    minIndex = i;
                    break;
                }
            }

            Debug.Log($"MIN = {minIndex}");
            Debug.Log($"_bonuses[min], {_bonuses[minIndex]}");

            Instantiate(_bonuses[minIndex], position, Quaternion.identity);
        }

        private void IntensivityInProcentCount()
        {
            int _intensivitiesSum = 0;

            Debug.Log($"_bonuses.Length = {_bonuses.Length}");

            for (int i = 0; i < _bonuses.Length; i++)
            {
                _intensivitiesSum += _bonuses[i].Intensivity;
            }

            Debug.Log($"INTENSIVITY SUM = {_intensivitiesSum}");

            for (int i = 0; i < _bonuses.Length; i++)
            {
                _bonusesIntensivity[i] = (float)_bonuses[i].Intensivity / _intensivitiesSum * 100;

                Debug.Log($"INTENSIVITY {i} = {_bonusesIntensivity[i]}");
            }
        }
    }
}