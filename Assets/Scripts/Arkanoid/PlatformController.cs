using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _border = 7.1f;
        [SerializeField] private float _sensivity;
        private float _mousePositionDelta;
        private Vector2 _oldMousePosition;
        [Space]
        [SerializeField] private Camera _mainCamera;
        private bool _canMove;


        private void Start()
        {
            _canMove = false;
        }

        public void FixedUpdate()
        {
            //с лекции
            //_rb.MovePosition(UseKeyboard());
            //_rb.MovePosition(UseMouse());

            //координаты платформы по 0x соответствуют координатам мышки на игровом экране
            //платформа не движетс€, пока не полктит м€ч
            if (Input.GetMouseButtonDown(0))
            {
                _canMove = true;
            }

            //?
            if (_canMove)
            {
                var oldPosition = transform.position;
                var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
                mouseWorldPosition = Mathf.Clamp(mouseWorldPosition, -_border, _border); ;
                oldPosition.x = mouseWorldPosition;
                transform.position = oldPosition;
            }
        }

        public Vector3 UseKeyboard()
        {
            var axis = Input.GetAxisRaw("Horizontal");

            var newPosition = transform.position;
            newPosition.x += _speed * Time.deltaTime * axis;
            newPosition.x = Mathf.Clamp(newPosition.x, -_border, _border);

            return newPosition;
        }

        public Vector3 UseMouse()
        {
            var newPosition = transform.position;

            _mousePositionDelta = Input.mousePosition.x - _oldMousePosition.x;
            newPosition.x += _mousePositionDelta * _sensivity * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -_border, _border);

            _oldMousePosition.x = Input.mousePosition.x;

            return newPosition;
        }
    }
}
