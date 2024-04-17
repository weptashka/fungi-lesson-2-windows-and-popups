using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyableBlock : BlockBase
    {
        [SerializeField] private int _blockHitPoints;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _hitNumberForDestroy;
        [Space]
        [SerializeField] private Sprite[] _sprites;

        public override BlockType Type => BlockType.Destroyable;


        private void Start()
        {
            if (_hitNumberForDestroy <= 0) 
            {
                _hitNumberForDestroy = 1;
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball))
            {
                _hitNumberForDestroy--;
                //Debug.Log(_hitNumberForDestroy);

                if (_hitNumberForDestroy <= _sprites.Length)
                {
                    if (_hitNumberForDestroy == 0)
                    {
                        //Debug.Log("DESTROYED");
                        Destroy(gameObject);
                    }
                    else
                    {
                        _spriteRenderer.sprite = _sprites[^_hitNumberForDestroy];
                        _spriteRenderer.size = new Vector2(1, 1);
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
