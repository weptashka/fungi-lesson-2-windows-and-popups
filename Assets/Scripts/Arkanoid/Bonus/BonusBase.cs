using System;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BonusBase : MonoBehaviour
    {
        public static event Action<BonusType> BonusPicked;

        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb;

        //плохо с ответственностями
        private AffectedPicker[] _affectedPeakers;

        [field: SerializeField]
        public AffectedType AffectedType
        {
            get;
            private set;
        }

        [field: SerializeField, Range(0, 100)]
        public int Intensivity
        { 
            get; 
            private set; 
        }

        public abstract BonusType BonusType
        {
            get;
        }

        private void Start()
        {
            _affectedPeakers = FindObjectsOfType<AffectedPicker>();
        }

        private void Update()
        {
            var transformPosition = transform.position;
            transformPosition.y += _speed * Time.deltaTime;
            _rb.MovePosition(transformPosition);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlatformController platforn))
            {
                BonusPicked?.Invoke(BonusType);

                //это надо куда-нибудь вынести
                foreach (var peaker in _affectedPeakers)
                {
                    if (peaker.AffectedType == this.AffectedType)
                    {
                        ApplyEffect(peaker);
                    }
                }

                gameObject.SetActive(false);
            }
        }

        protected abstract void ApplyEffect(AffectedPicker _affectedPicker);
    }
}
