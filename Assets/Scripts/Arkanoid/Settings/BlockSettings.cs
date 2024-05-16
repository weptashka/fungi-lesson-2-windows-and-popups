using System;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    [CreateAssetMenu(menuName = "Settings/BlocksSettings", fileName = "BlockSettings", order = 0)]
    public class BlockSettings : ScriptableObject
    {
        [SerializeField] private Sprite[] _sprites;
        [Space]
        [SerializeField] private BlockPreset _blockPreset;

        public Sprite[] Sprites => _sprites;
    }


    [Serializable]
    public class BlockPreset
    {
        [SerializeField] private BlockType _blockType;
        [SerializeField] private BlockType _sprite;
        [SerializeField] private int _life;
        [SerializeField] private int _pointCount;
    }
}
