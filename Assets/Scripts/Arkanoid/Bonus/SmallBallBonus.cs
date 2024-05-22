using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class SmallBallBonus : BonusBase
    {
        [SerializeField] private float _multipliedScale;

        public override BonusType BonusType => BonusType.SmallBall;

        protected override void ApplyEffect(AffectedPicker _pickableEffecter)
        {
            var transformLocalScale = _pickableEffecter.transform.localScale;
            transformLocalScale *= -_multipliedScale;
            _pickableEffecter.transform.localScale = transformLocalScale;
        }
    }
}