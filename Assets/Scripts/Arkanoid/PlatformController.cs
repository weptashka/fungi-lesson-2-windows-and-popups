using System;
using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class PlatformController : MonoBehaviour
    {
        public static event Action BallTochedPlatform;

        [SerializeField] private SpriteRenderer _platformSpriteRenderer;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _sensivity;
        [Space]
        [SerializeField] private Camera _mainCamera;

        private Vector3 _leftPoint;
        private Vector3 _rightPoint;
        private float _mousePositionDelta;
        private Vector2 _oldMousePosition;
        private string _horizontalAxis = "Horizontal";
        private int _platformScale;

        public void Start()
        {
            _platformScale = 1;
            CountPlatformSize();
        }

        public void FixedUpdate()
        {
            var oldPosition = transform.position;
            var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            mouseWorldPosition = Mathf.Clamp(mouseWorldPosition, _leftPoint.x, _rightPoint.x); ;
            oldPosition.x = mouseWorldPosition;
            transform.position = oldPosition;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball))
            {
                CountPlatformSize();
                BallTochedPlatform?.Invoke();
            }
        }

        public void CountPlatformSize()
        {
            var platformSpriteRendererSize = _platformSpriteRenderer.size;
            var halfPlatformSize = platformSpriteRendererSize.x / 2;

            _leftPoint = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
            _leftPoint.x += halfPlatformSize;
            _rightPoint = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0));
            _rightPoint.x -= halfPlatformSize;

            Debug.Log($"_leftPoint.x = {_leftPoint.x} _rightPoint.x ={_rightPoint.x}");
        }

        public Vector3 UseKeyboard()
        {
            var axis = Input.GetAxisRaw(_horizontalAxis);

            var newPosition = transform.position;
            newPosition.x += _speed * Time.deltaTime * axis;
            newPosition.x = Mathf.Clamp(newPosition.x, _leftPoint.x, _rightPoint.x);

            return newPosition;
        }

        public Vector3 UseMouse()
        {
            var newPosition = transform.position;

            _mousePositionDelta = Input.mousePosition.x - _oldMousePosition.x;
            newPosition.x += _mousePositionDelta * _sensivity * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, _leftPoint.x, _rightPoint.x);

            _oldMousePosition.x = Input.mousePosition.x;

            return newPosition;
        }
    }
}
