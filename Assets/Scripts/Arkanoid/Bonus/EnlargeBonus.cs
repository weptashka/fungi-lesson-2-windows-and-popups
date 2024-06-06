using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class EnlargeBonus : BonusBase
    {
        [SerializeField] private float _addedScale;

        public override BonusType BonusType => BonusType.Enlarge;

        protected override void ApplyEffect(AffectedPicker _pickableEffecter)
        {
            var transformLocalScale = _pickableEffecter.transform.localScale;
            transformLocalScale.x += _addedScale;
            _pickableEffecter.transform.localScale = transformLocalScale;
        }
    }
}