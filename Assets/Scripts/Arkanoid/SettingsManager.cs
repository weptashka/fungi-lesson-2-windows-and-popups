using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;

        //[SerializeField] private LevelSettings _levelSettings;
        //public LevelSettings levelSettings => _levelSettings;

        [SerializeField] private BlockSettings _blockSettings;
        public BlockSettings BlockSettings => _blockSettings;

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
