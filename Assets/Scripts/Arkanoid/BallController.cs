using UnityEngine;

 namespace Assets.Scripts.Arkanoid
{
    public class BallController : MonoBehaviour
    {
        private float xRange = 150f;
        private float speedSquare = 90000f;

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startForce;
        [SerializeField] private PhysicsMaterial2D _ballPhysicsMaterial2D;


        private void Awake()
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.sharedMaterial = null;
            _rb.gravityScale = 1;

            var x = Random.Range(-xRange, xRange);
            var y = Mathf.Sqrt(speedSquare - x);
            _startForce = new Vector2(x, y);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0) && (_rb.velocity.x == 0 || _rb.velocity.y == 0))
            {
                _rb.sharedMaterial = _ballPhysicsMaterial2D;
                _rb.gravityScale = 0;
                _rb.velocity = Vector2.zero;
                _rb.AddForce(_startForce);
                Debug.Log("FORCE");
            }
        }
    }
}
