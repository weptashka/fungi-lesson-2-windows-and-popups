using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomTouchController : MonoBehaviour
{
    [SerializeField] private string _uiSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallController ball))
        {
            SceneManager.LoadScene(_uiSceneName);
        }
    }
}
