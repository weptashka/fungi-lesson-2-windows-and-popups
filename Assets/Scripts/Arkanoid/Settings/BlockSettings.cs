using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    [CreateAssetMenu(menuName = "Settings/BlocksSettings", fileName = "BlockSettings", order = 0)]
    public class BlockSettings : ScriptableObject
    {
        [SerializeField] private Sprite[] _sprites;
        [Space]
        [SerializeField] private BlockPreset[] _blockPresets;

        public BlockPreset[] BlockPresets => _blockPresets;
        public Sprite[] Sprites => _sprites;

        public BlockPreset GetPresetByBlockType(BlockType blockType)
        {
            var blockPreset = _blockPresets.FirstOrDefault(x => x.BlockType == blockType);

            if (blockPreset == null)
            {
                Debug.LogError("BlockPreset Not Found");
            }

            return blockPreset;
        }
    }

    [Serializable]
    public class BlockPreset
    {
        [SerializeField] private BlockType _blockType;
        [SerializeField] private Sprite _blockSprite;
        [Min(1)]
        [SerializeField] private int _hitNumberForDestroy;
        [SerializeField] private int _blockHitpoints;
        [SerializeField] private bool _isGeneratesBonus;

        public BlockType BlockType => _blockType;
        public Sprite BlockSprite => _blockSprite;
        public int HitNumberForDestroy => _hitNumberForDestroy;
        public int BlockHitpoints => _blockHitpoints;
        public bool IsGeneratedBonus => _isGeneratesBonus;
    }
}
