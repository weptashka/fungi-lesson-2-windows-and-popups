using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class InvisibleBlock : DestroyableBlock
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _blockSprite;

        private bool _firstCollision;


        public override void Start()
        {
            base.Start();
            _firstCollision = false;
            _spriteRenderer.sprite = null;
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball) && _firstCollision == false)
            {
                _firstCollision = true;
                _spriteRenderer.sprite = _blockSprite;
            }

            base.OnCollisionEnter2D(collision);
        }
    }
}
