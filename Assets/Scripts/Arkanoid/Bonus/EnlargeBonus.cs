namespace Assets.Scripts.Arkanoid
{
    public class EnlargeBonus : BonusBase
    {
        public override BonusType Type => BonusType.Enlarge;

        protected override void ApplyEffect(PickableEffector _pickableEffecter)
        {
            _pickableEffecter.MakeLarge();
        }
    }
}
