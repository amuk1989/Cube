using System.Collections.Generic;
using UnityEngine;

namespace CubeAdvetures
{
    public class GameController : MonoBehaviour, IController
    {
        #region Serializable

        [SerializeField] private PlayerController _playerController;

        #endregion

        private List<IController> _controllers;
        private InputController _inputController;

        private void Start()
        {
            Inicilize();
        }

        private void Update()
        {
            Updating();
        }

        public void Inicilize()
        {
            _controllers = new List<IController>();
            _inputController = new InputController();
            _controllers.Add(_inputController);
            _controllers.Add(_playerController);

            _controllers.ForEach(controller => controller.Inicilize());
        }

        public void Updating()
        {
            _controllers.ForEach(controller => controller.Updating());
            _playerController.MoveTo(_inputController.direction);
        }
    }
}