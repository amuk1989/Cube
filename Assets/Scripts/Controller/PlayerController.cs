using System.Collections;
using UnityEngine;

namespace CubeAdvetures
{
    public class PlayerController : MonoBehaviour, IController
    {
        #region Serialized

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed;
        [SerializeField] private float _speedRotation = 0.5f;
        [SerializeField] private int _step = 1;

        #endregion

        #region Variables

        private bool isCanCommand = true;
        private float _timeCount = 0.0f;
        private Vector3 _destinatePosition;
        private Vector3 _forwardDirection = Vector3.forward;
        private Quaternion _destinateRotation;

        #endregion

        #region Methods
        public void Inicilize()
        {
            _destinatePosition = _playerTransform.position;
            _destinateRotation = _playerTransform.rotation;
            _playerTransform.position = Vector3.zero;
            _playerTransform.rotation = Quaternion.Euler(Vector3.zero);
        }

        public void Updating()
        {
            _playerTransform.position = Vector3.Lerp(_playerTransform.position, _destinatePosition, _timeCount);
            _timeCount += Time.deltaTime * 0.1f;
            _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, _destinateRotation, _timeCount);
            _timeCount += Time.deltaTime * _speedRotation;

            if (
                (_playerTransform.position == _destinatePosition)
                &&
                (Quaternion.Angle(transform.rotation, _destinateRotation) < 0.05)
                )
            {
                isCanCommand = true;
                _timeCount = 0;
            }
        }

        public void MoveTo(Direction direction)
        {
            if (isCanCommand)
            {
                switch (direction)
                {
                    case Direction.Forward:
                        _destinatePosition += _forwardDirection * _step;
                        _animator.SetTrigger("Forward");
                        isCanCommand = false;
                        break;
                    case Direction.Back:
                        _destinatePosition -= _forwardDirection * _step;
                        _animator.SetTrigger("Back");
                        isCanCommand = false;
                        break;
                    case Direction.Right:
                        _destinateRotation = RotateTo(_destinateRotation, Vector3.up);
                        _forwardDirection = RotateVector(_forwardDirection, RotateDirection.ClockWise);
                        isCanCommand = false;
                        break;
                    case Direction.Left:
                        _destinateRotation = RotateTo(_destinateRotation, Vector3.down);
                        _forwardDirection = RotateVector(_forwardDirection, RotateDirection.ConterClockWise);
                        isCanCommand = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private Quaternion RotateTo(Quaternion startRotate, Vector3 axesOfRotation)
        {
            var from = Quaternion.Euler(startRotate.eulerAngles);
            var to = Quaternion.Euler(from.eulerAngles + (axesOfRotation * 90));
            var result = to;
            return result;
        }

        private Vector3 RotateVector(Vector3 vector, RotateDirection rotateDirection)
        {
            Vector3 result;
            if (rotateDirection == RotateDirection.ClockWise)
            {
                result = new Vector3(vector.z, vector.y, -vector.x);
            }
            else
            {
                result = new Vector3(-vector.z, vector.y, vector.x);
            }
            return result;
        }
        #endregion
    }
}