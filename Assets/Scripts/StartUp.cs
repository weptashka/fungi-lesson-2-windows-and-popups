using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

    public class StartUp : MonoBehaviour
    {
        [SerializeField] private string _uiSceneName;

        private void Start()
        {
            SceneManager.LoadScene(_uiSceneName);
        }
    }
}
