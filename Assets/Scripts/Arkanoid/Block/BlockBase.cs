using UnityEngine;

namespace Assets.Scripts
{
    public abstract class BlockBase : MonoBehaviour
    {
        public abstract BlockType Type
        {
            get;
        }
    }
}

