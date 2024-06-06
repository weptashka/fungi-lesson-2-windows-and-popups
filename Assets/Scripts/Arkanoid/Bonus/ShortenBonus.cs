using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class ShortenBonus : BonusBase
    {
        [SerializeField] private float _substractedScale;

        public override BonusType BonusType => BonusType.Shorten;

        protected override void ApplyEffect(AffectedPicker _pickableEffecter)
        {
            var transformLocalScale = _pickableEffecter.transform.localScale;
            transformLocalScale.x -= _substractedScale;
            _pickableEffecter.transform.localScale = transformLocalScale;
        }
    }
}