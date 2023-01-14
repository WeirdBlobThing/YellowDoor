using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEventArgs : EventArgs
{
    public bool IsPaused { get; set; }
}

public class GameManager : MonoBehaviour
{

    public event EventHandler<PauseEventArgs> OnPauseChanged;

    public static GameManager Instance;
    
    private bool m_isPaused = false;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.P)) {
            m_isPaused = !m_isPaused;

            OnPauseChanged?.Invoke(this, new PauseEventArgs() { IsPaused = m_isPaused });
        }
    }
}
