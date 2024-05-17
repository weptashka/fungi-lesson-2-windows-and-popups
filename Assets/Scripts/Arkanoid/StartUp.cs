using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Arkanoid
{

    public class StartUp : MonoBehaviour
    {
        //  [SerializeField] private string _uiSceneName;
        [SerializeField] private SettingsManager _settingsManager;
        [SerializeField] private LevelLoader _levelLoader;

        private void Awake()
        {
            _settingsManager.Init();
            _levelLoader.Init();


            _levelLoader.LoadScene(_settingsManager.LevelSettings.UISceneName);
            //SceneManager.LoadScene(_settingsManager.LevelSettings.UISceneName);
            //SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        }

        //[SerializeField] private SettingsManager _settingsManager;
        //[SerializeField] private LevelLoader _levelLoader;
        ////[Space]
        ////[SerializeField] private TouchInputController _touchInput;


        //private void Awake()
        //{
        //    _settingsManager.Init();
        //    _levelLoader.Init();

        //    //StartCoroutine(LoadScenes(() =>
        //    //{
        //    //    DontDestroyOnLoad(_touchInput);
        //    //    DontDestroyOnLoad(UISystem.Instance);
        //    //    UISystem.Instance.transform.SetAsLastSibling();

        //    //}));
        //}

    }
}
