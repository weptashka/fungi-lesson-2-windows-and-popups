using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Arkanoid
{
    [CreateAssetMenu(menuName = "Settings/LevelSettings", fileName = "LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private string _uiSceneName;

        [FormerlySerializedAs("_levelName")]
        [SerializeField] private string[] _levelNames;

        public string UISceneName => _uiSceneName;
        public string[] LevelNames => _levelNames;
        

        //[SerializeField] private string _gameSceneName;
        //[SerializeField] private GameObject[] _levels;

        //public string GameSceneName => _gameSceneName;
        //public GameObject[] Levels => _levels;
    }
}
