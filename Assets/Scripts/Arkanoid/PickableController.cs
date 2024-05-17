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
        [SerializeField] private EnlargeBonus _enlargeBonus;

        private DestroyableBlock[] _destroyableBlock;
        private int _destroyBlockCount;
        private int _range = -1;

        private void Awake()
        {
            _destroyableBlock = _blockParent.GetComponentsInChildren<DestroyableBlock>();

            foreach (var block in _destroyableBlock)
            {
                block.Setup(this);
            }
        }

        public void OnBlockDestroyed(Vector3 position)
        {
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
            Instantiate(_enlargeBonus, position, Quaternion.identity);
        }
    }
}