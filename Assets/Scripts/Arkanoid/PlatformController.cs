using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _sensivity;
        private Vector3 _leftPoint;
        private Vector3 _rightPoint;
        [SerializeField] private SpriteRenderer _boardSpriteRenderer;
        private float _mousePositionDelta;
        private Vector2 _oldMousePosition;
        [Space]
        [SerializeField] private Camera _mainCamera;
        private bool _canMove;


        public void Start()
        {
            _canMove = false;
            var boardSpriteRendererSize = _boardSpriteRenderer.size;
            var halfBoardSize = boardSpriteRendererSize.x / 2;

            _leftPoint = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
            _leftPoint.x += halfBoardSize;
            _rightPoint = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0));
            _rightPoint.x -= halfBoardSize;
        }

        public void FixedUpdate()
        {
            //� ������
            //_rb.MovePosition(UseKeyboard());
            //_rb.MovePosition(UseMouse());

            //���������� ��������� �� 0x ������������� ����������� ����� �� ������� ������
            //��������� �� ��������, ���� �� ������� ���
            if (Input.GetMouseButtonDown(0))
            {
                _canMove = true;
            }

            //?
            if (_canMove)
            {
                var oldPosition = transform.position;
                var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
                mouseWorldPosition = Mathf.Clamp(mouseWorldPosition, _leftPoint.x, _rightPoint.x); ;
                oldPosition.x = mouseWorldPosition;
                transform.position = oldPosition;
            }
        }

        public Vector3 UseKeyboard()
        {
            var axis = Input.GetAxisRaw("Horizontal");

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
