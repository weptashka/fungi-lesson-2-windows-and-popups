using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public abstract class BlockBase : MonoBehaviour
    {
        public abstract BlockType Type
        {
            get;
        }
    }
}

