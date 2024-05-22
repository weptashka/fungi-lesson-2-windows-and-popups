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
        [Space]
        [SerializeField] private Transform _parentGameContent;

        private void Awake()
        {
            _rb.bodyType = RigidbodyType2D.Static;
            _rb.sharedMaterial = null;

            var x = Random.Range(-xRange, xRange);
            var y = Mathf.Sqrt(speedSquare - x);
            _startForce = new Vector2(x, y);

            var ballSpriteRendererSize = _ballSpriteRenderer.size;
            var ballRadiusSize = ballSpriteRendererSize.y / 2;

            var boardSpriteRendererSize = _platformSpriteRenderer.size;
            var halfPlatformYSize = boardSpriteRendererSize.y / 2;

            var transformPosition = transform.position;
            transformPosition.x = _parentPlatform.transform.position.x;
            transformPosition.y = _parentPlatform.transform.position.y + halfPlatformYSize + ballRadiusSize;
            transform.position = transformPosition;

            gameObject.transform.SetParent(_parentPlatform, true);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0) && (_rb.velocity.x == 0 || _rb.velocity.y == 0))
            {
                gameObject.transform.SetParent(_parentGameContent);
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
