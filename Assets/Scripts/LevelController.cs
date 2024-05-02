using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static event Action<int> ScoreChanged;


    [SerializeField] private GameObject _gameContent;

    private int _score;

    private void Awake()
    {

        _gameContent.SetActive(false);
    }

    private void OnEnable()
    {
        StartWindow.LevelStarted += StartWindowOnLevelStarted;
        DestroyableBlock.Destroyed += DestroyableBlockOnDestroyed;
        FailedLevelTrigger.LevelFailed += LevelFailed;
    }
    
    private void OnDisable()
    {
        StartWindow.LevelStarted -= StartWindowOnLevelStarted;
        DestroyableBlock.Destroyed -= DestroyableBlockOnDestroyed;
        FailedLevelTrigger.LevelFailed -= LevelFailed;

    }

    private void StartWindowOnLevelStarted()
    {
        _score = 0;
        _gameContent.SetActive(true);
    }

    private void DestroyableBlockOnDestroyed(int blockHitPoints)
    {
        _score += blockHitPoints;
        ScoreChanged?.Invoke(_score);
    }

    public void LevelFailed()
    {
        UISystem.Instance.OpenWindow(WindowType.Fail, true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
