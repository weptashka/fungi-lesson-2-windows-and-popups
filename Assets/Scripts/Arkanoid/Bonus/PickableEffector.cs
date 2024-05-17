using UnityEngine;

namespace Assets.Scripts.Arkanoid
{
    public class PickableEffector : MonoBehaviour
    {
        public void MakeLarge()
        { 
            var transformLocalScale = transform.localScale;
            transformLocalScale.x += 2;
            transform.localScale = transformLocalScale;
        }
    }
}
