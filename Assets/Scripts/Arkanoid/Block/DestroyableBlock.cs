using UnityEngine;
using System;

namespace Assets.Scripts.Arkanoid
{
    public class DestroyableBlock : BlockBase
    {
        public static event Action<int> Destroyed;

        [SerializeField] private SpriteRenderer _blockRenderer;
        [SerializeField] private SpriteRenderer _crackRenderer;
        [SerializeField] private PickableController _pickableController;
        [SerializeField] private BlockType _blockType;

        private Sprite[] _sprites;
        private BlockPreset _blockSetting;
        private int _blockHitPoints;
        private int _hitNumberForDestroy;

        [field: SerializeField]
        public bool IsGeneratesBonus
        { 
            get; 
            private set; 
        }

        public override BlockType Type => BlockType.Destroyable;

        public virtual void Awake()
        {
            _sprites = SettingsManager.Instance.BlockSettings.Sprites;

            _blockSetting = SettingsManager.Instance.BlockSettings.GetPresetByBlockType(_blockType);
            _blockHitPoints = _blockSetting.BlockHitpoints;
            _hitNumberForDestroy = _blockSetting.HitNumberForDestroy;
            _blockRenderer.sprite = _blockSetting.BlockSprite;
            IsGeneratesBonus = _blockSetting.IsGeneratedBonus;
        }

        public void Setup(PickableController pickableController)
        {
            _pickableController = pickableController;
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
                        if (IsGeneratesBonus)
                        {
                            _pickableController.OnBlockDestroyed(transform.position);
                        }
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
