using UnityEngine;

 namespace Assets.Scripts.Arkanoid
{
    public class BallController : MonoBehaviour
    {
        private float xRange = 150f;
        private float speedSquare = 90000f;

        [SerializeField] private SpriteRenderer _ballSpriteRenderer;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private PhysicsMaterial2D _ballPhysicsMaterial2D;
        [SerializeField] private Vector2 _startForce;
        [Space]
        [SerializeField] private Transform _parentPlatform;
        [SerializeField] private SpriteRenderer _platformSpriteRenderer;


        private void Awake()
        {
            _rb.bodyType = RigidbodyType2D.Static;
            _rb.sharedMaterial = null;

            var x = Random.Range(-xRange, xRange);
            var y = Mathf.Sqrt(speedSquare - x);
            _startForce = new Vector2(x, y);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0) && (_rb.velocity.x == 0 || _rb.velocity.y == 0))
            {
                gameObject.transform.SetParent(null);
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _rb.sharedMaterial = _ballPhysicsMaterial2D;
                _rb.gravityScale = 0;
                _rb.velocity = Vector2.zero;
                _rb.AddForce(_startForce);
                Debug.Log("FORCE");
            }
        }
    }
}
