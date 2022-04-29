using System;
using UnityEngine;
using UnityEngine.UI;


internal sealed class UserInterface : MonoBehaviour
{
    [SerializeField] private MainPanel _mainPanel;
    [SerializeField] private BtnBack _BtnBack;
    [SerializeField] private BtnRestart _BtnRestart;
    private bool _isPanelActive;

    private void Start()
    {
        _mainPanel.Cancel();
        _isPanelActive = false;
    }
        

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_mainPanel.gameObject.activeSelf)
            {
                _mainPanel.Cancel();
                _isPanelActive = false;
            }
            else
            {
                _mainPanel.Execute();
                _isPanelActive = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(_isPanelActive)
            {
                _BtnBack.Execute();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isPanelActive)
            {
                _BtnRestart.Execute();
            }
        }

    }

}

