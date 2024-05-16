using UnityEngine;
using System;

namespace Assets.Scripts.Arkanoid
{
    public class DestroyableBlock : BlockBase
    {
        public static event Action<int> Destroyed;

        //[SerializeField] protected int _blockHitPoints;
        //[Min(1)]
        //[SerializeField] protected int _hitNumberForDestroy;
        //[Space]
        //[SerializeField] protected Sprite[] _spritesRef;

        [SerializeField] protected SpriteRenderer _blockRenderer;
        [SerializeField] protected SpriteRenderer _crackRenderer;
        [SerializeField] private BlockType _blockType;

        private Sprite[] _sprites;
        private BlockPreset _blockSetting;

        private int _blockHitPoints;
        private int _hitNumberForDestroy;

        public override BlockType Type => BlockType.Destroyable;


        public virtual void Start()
        {
            //_sprites = _spritesRef;

            _sprites = SettingsManager.Instance.BlockSettings.Sprites;

            _blockSetting = SettingsManager.Instance.BlockSettings.GetPresetByBlockType(_blockType);
            _blockHitPoints = _blockSetting.BlockHitpoints;
            _hitNumberForDestroy = _blockSetting.HitNumberForDestroy;
            _blockRenderer.sprite = _blockSetting.BlockSprite;
        }

        public virtual void OnCollisionEnter2D(Collision2D collision)
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
                        Debug.Log($"_hitNumberForDestroy = {_hitNumberForDestroy}");
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
