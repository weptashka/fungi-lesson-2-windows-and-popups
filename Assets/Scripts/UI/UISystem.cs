using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private WindowBase[] _windows;

        public static UISystem Instance;
        private WindowBase _currentWindow;

        [SerializeField] private List<WindowBase> _openedWindows;



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }


        private void Start()
        {
            _windows = GetComponentsInChildren<WindowBase>(true);

            DontDestroyOnLoad(gameObject);

            foreach (var window in _windows)
            {
                window.Close();
            }

            OpenWindow(WindowType.Start, false);
        }



        public void OpenWindow(WindowType windowType, bool setAsLastSibling)
        {
            var windowToOpen = _windows.FirstOrDefault(x => x.Type == windowType);

            if (windowToOpen == null)
            {
                return;
            }

            if (setAsLastSibling)
            {
                windowToOpen.transform.SetAsLastSibling();
            }

            if (_openedWindows.Contains(windowToOpen))
            {
                return;
            }

            if (!windowToOpen.IsPopup)
            {
                if (_currentWindow != null)
                {
                    foreach (var window in _openedWindows)
                    {
                        window.Close();
                    }
                    _currentWindow.Close();
                }
                _openedWindows.Clear();
            }

            windowToOpen.Open();
            _currentWindow = windowToOpen;
            _openedWindows.Add(windowToOpen);
        }


        public void Close(WindowType windowType)
        {
            var windowToClose = _windows.FirstOrDefault(x => x.Type == windowType);

            if (windowToClose == null)
            {
                return;
            }

            if (!_openedWindows.Contains(windowToClose))
            {
                return;
            }

            if (_openedWindows.Count <= 1)
            {
                return;
            }

            var indexOf = _openedWindows.IndexOf(windowToClose);
            _openedWindows[indexOf].Close();
            _openedWindows.Remove(_openedWindows[indexOf]);
            _currentWindow = _openedWindows[^1];
        }
    }
}
