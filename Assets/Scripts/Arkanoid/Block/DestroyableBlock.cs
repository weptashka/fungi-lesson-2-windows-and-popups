using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class DestroyableBlock : BlockBase
    {
        public static event Action<int> Destroyed;


        [SerializeField] protected int _blockHitPoints;
        [Min(1)]
        [SerializeField] protected int _hitNumberForDestroy;
        [Space]
        [SerializeField] protected SpriteRenderer _crackRenderer;
        [SerializeField] private Sprite[] _sprites;
     


        public override BlockType Type => BlockType.Destroyable;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball))
            {
                _hitNumberForDestroy--;

                if (_hitNumberForDestroy <= _sprites.Length)
                {
                    if (_hitNumberForDestroy == 0)
                    {
                        gameObject.SetActive(false);
                        Destroyed?.Invoke(_blockHitPoints);
                    }
                    else
                    {
                        _crackRenderer.sprite = _sprites[^_hitNumberForDestroy];
                    }
                }
            }
        }




            public int GetHitPoints()
        {
            return _blockHitPoints;
        }

    }
}
