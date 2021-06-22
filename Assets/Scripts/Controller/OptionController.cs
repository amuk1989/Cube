using System.Collections;
using UnityEngine;

namespace CubeAdvetures
{
    public class OptionController : MonoBehaviour
    {
        [SerializeField] public KeyCode forward = KeyCode.W;
        [SerializeField] public KeyCode right = KeyCode.D;
        [SerializeField] public KeyCode left = KeyCode.A;
        [SerializeField] public KeyCode back = KeyCode.S;
    }
}