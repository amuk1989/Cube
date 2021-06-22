using System.Collections;
using UnityEngine;

namespace CubeAdvetures
{
    public class PlayerController : MonoBehaviour, IController
    {
        #region Serialized

        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private int _step = 1;

        #endregion

        #region Variables

        private bool isCanCommand = true;
        private float _timeCount = 10.0f;
        private Transform _playerTrasform;
        private Vector3 _destinatePosition;
        private Vector3 _direction = Vector3.zero;
        private Quaternion _destinateRotation;

        #endregion
        public void Inicilize()
        {
            _playerTrasform = gameObject.transform;
            _destinatePosition = _playerTrasform.position;
            _destinateRotation = _playerTrasform.rotation;
        }

        public void Updating()
        {
            if (!isCanCommand)
            {
                if (Vector3.Distance(_playerTrasform.position, _destinatePosition) > 0.01)
                {
                    _playerTrasform.position += _direction * Time.deltaTime * _speed;
                }

                if (
                    (Quaternion.Angle(_playerTrasform.rotation, _destinateRotation) <= 0.01)
                    &&
                    (Vector3.Distance(_playerTrasform.position, _destinatePosition) <= 0.01)
                    )
                {
                    _playerTrasform.position = _destinatePosition;
                    _playerTrasform.rotation = _destinateRotation;
                    _timeCount = 0;
                    isCanCommand = true;
                }

            }
            
        }

        public void MoveTo(Direction direction)
        {
            if (isCanCommand)
            {
                switch (direction)
                {
                    case Direction.Forward:
                        Debug.Log("F");
                        _direction = Vector3.forward * _step;
                        isCanCommand = false;
                        break;
                    case Direction.Back:
                        Debug.Log("B");
                        _direction = Vector3.back * _step;
                        isCanCommand = false;
                        break;
                    case Direction.Right:
                        Debug.Log("R");
                        _destinateRotation = RotateTo(_destinateRotation, Vector3.right);
                        isCanCommand = false;
                        break;
                    case Direction.Left:
                        Debug.Log("L");
                        isCanCommand = false;
                        break;
                    default:
                        Debug.Log("Unknow");
                        _direction = Vector3.zero;
                        break;
                }
                _destinatePosition += _direction;
            }
        }

        private Quaternion RotateTo(Quaternion startRotate, Vector3 axesOfRotation)
        {
            var from = startRotate.eulerAngles;
            var to = from + (axesOfRotation * 90);
            var result = Quaternion.Euler(to);
            return result;
        }

    }
}