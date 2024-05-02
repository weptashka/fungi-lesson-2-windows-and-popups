using UnityEngine;

namespace Assets.Scripts.Arkanoid.Block
{
    public class InvisibleBlock : DestroyableBlock
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _blockSprite;



        private bool _firstCollision ;

        private void Start()
        {
            _firstCollision = true;
            _spriteRenderer.sprite = null;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball) && _firstCollision == true)
            {
                _firstCollision = false;
                _spriteRenderer.sprite = _blockSprite;
            }
        }
    }
}
