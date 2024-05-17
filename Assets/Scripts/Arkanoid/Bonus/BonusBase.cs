using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BonusBase : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb;

        public abstract BonusType Type
        {
            get;
        }

        private void Update()
        {
            var transformPosition = transform.position;
            transformPosition.y += _speed * Time.deltaTime;
            _rb.MovePosition(transformPosition);
        }

        protected abstract void ApplyEffect(PickableEffector _pickableEffecter);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PickableEffector platform))
            {
                ApplyEffect(platform);
                gameObject.SetActive(false);
            }
        }
    }
}
