using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Assets.Scripts.Arkanoid
{

    public class StartUp : MonoBehaviour
    {
        //  [SerializeField] private string _uiSceneName;
        [SerializeField] private SettingsManager _settingsManager;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private LevelController _levelController;

        private void Awake()
        {
            _settingsManager.Init();
            _levelLoader.Init();
            //_playerController.Init();
            //_levelController.Init();

            //LevelLoader.Instance.LoadScene(_settingsManager.LevelSettings.UISceneName);

            //_levelLoader.LoadScene(_settingsManager.LevelSettings.UISceneName);

            //SceneManager.LoadScene(_settingsManager.LevelSettings.UISceneName);
            //SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);

            _settingsManager.Init();

            StartCoroutine(LoadScenes(() =>
            {
                DontDestroyOnLoad(UISystem.Instance);
                UISystem.Instance.transform.SetAsLastSibling();
            }));


            IEnumerator LoadScenes(Action callBack)
            {
                AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(_settingsManager.LevelSettings.UISceneName, LoadSceneMode.Additive);

                while (!loadSceneAsync.isDone)
                {
                    yield return null;
                }

                SceneManager.LoadScene(_settingsManager.LevelSettings.GameSceneName);

                callBack.Invoke();
            }
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
