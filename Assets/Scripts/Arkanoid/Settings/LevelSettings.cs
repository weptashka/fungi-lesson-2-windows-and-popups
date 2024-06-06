using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Arkanoid
{
    [CreateAssetMenu(menuName = "Settings/LevelSettings", fileName = "LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private string _uiSceneName;
        [SerializeField] private string _gameSceneName;

        [FormerlySerializedAs("_levelPrefabs")]
        [SerializeField] private GameObject[] _levelPefabs;
        
        public string UISceneName => _uiSceneName;
        public string GameSceneName => _gameSceneName;
        public GameObject[] LevelPrefabs => _levelPefabs;
    }
}
