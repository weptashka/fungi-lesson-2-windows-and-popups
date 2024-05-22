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

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
