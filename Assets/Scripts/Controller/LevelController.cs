using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeAdvetures
{
    public class LevelController: MonoBehaviour
    {
        [SerializeField] private GameObject _finish;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private int _nextLevel;

        public GameObject FinishPoint { get => _finish; }
        public Transform StartPoint { get => _startPoint; }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(_nextLevel);
        }

    }
}
