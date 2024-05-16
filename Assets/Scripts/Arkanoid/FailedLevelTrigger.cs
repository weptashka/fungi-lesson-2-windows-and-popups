using System;
using UnityEngine;


namespace Assets.Scripts.Arkanoid
{
    public class FailedLevelTrigger : MonoBehaviour
    {
        public static event Action LevelFailed = delegate { };


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ball))
            {
                LevelFailed?.Invoke();
            }
        }
    }
}
