using UnityEngine;

namespace Assets.Scripts
{
    public abstract class WindowBase : MonoBehaviour
    {
        public abstract WindowType Type
        {
            get;
        }

        public abstract bool IsPopup
        {
            get;
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
