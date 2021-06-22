using System.Collections;
using UnityEngine;

namespace CubeAdvetures
{
    public class InputController : IController
    {
        /// <summary>
        /// Отвечает за ввод мыши или клавы
        /// </summary>
        /// 

        private OptionController _options;
        private Direction _moveDirection = Direction.Stop;

        public Direction direction{ get => _moveDirection; }

        public void Inicilize()
        {
            _options = GameObject.FindObjectOfType<OptionController>().GetComponent<OptionController>();
        }

        public void Updating()
        {
            if (Input.GetKey(_options.forward))
            {
                _moveDirection = Direction.Forward;
            }
            if (Input.GetKey(_options.back))
            {
                _moveDirection = Direction.Back;
            }
            if (Input.GetKey(_options.left))
            {
                _moveDirection = Direction.Left;
            }
            if (Input.GetKey(_options.right))
            {
                _moveDirection = Direction.Right;
            }
            if (!Input.anyKey)
            {
                _moveDirection = Direction.Stop;
            }
        }

    }
}