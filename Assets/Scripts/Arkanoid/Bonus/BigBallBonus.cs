using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class BigBallBonus : BonusBase
    {
        [SerializeField] private float _multipliedScale;

        [field: SerializeField]
        public int TouchNumberBeforeDisable
        {
            get;
            private set;
        }

        public override BonusType BonusType => BonusType.BigBall;

        protected override void ApplyEffect(AffectedPicker _pickableEffecter)
        {
            var transformLocalScale = _pickableEffecter.transform.localScale;
            transformLocalScale *= _multipliedScale;
            _pickableEffecter.transform.localScale = transformLocalScale;
        }
    }
}