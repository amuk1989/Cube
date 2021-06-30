using System.Collections.Generic;
using UnityEngine;

namespace CubeAdvetures
{
    public class GameController : MonoBehaviour, IController
    {
        #region Serializable

        [SerializeField] private LevelController _levelController;
        [SerializeField] private GameObject _charackter;
        [SerializeField] private Transform _playerSpawner;

        #endregion

        private List<IController> _controllers;
        private InputController _inputController;
        private PlayerController _playerController;

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
            _playerController = Instantiate(_charackter, _playerSpawner).GetComponent<PlayerController>();
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