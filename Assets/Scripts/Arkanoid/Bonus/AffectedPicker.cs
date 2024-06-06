using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class AffectedPicker : MonoBehaviour
    {
        [field: SerializeField]
        public AffectedType AffectedType
        {
            get;
            private set;
        }
    }
}
