using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField]
    private float m_defaultStartTimeInSeconds = 600;

    private float m_secondsLeft;
    private bool m_countingSeconds = true;

    private void Awake() {
        Instance = this;
        Reset();
    }

    private void Start() {
        GameManager.Instance.OnPauseChanged += OnPauseChanged;
    }

    public void OnPauseChanged(object sender, PauseEventArgs pauseEventArgs) {
        if (pauseEventArgs.IsPaused) {
            Pause();
        } else {
            Unpause();
        }
    }

    public float GetTimeInSeconds() {
        return m_secondsLeft;
    }

    public void AddSeconds(float seconds) {
        m_secondsLeft += seconds;
    }

    public void Pause() {
        m_countingSeconds = false;
    }

    public void Unpause() {
        m_countingSeconds = true;
    }

    private void Reset() {
        m_secondsLeft = m_defaultStartTimeInSeconds;
    }

    private void Update() {
        if (!m_countingSeconds) {
            return;
        }

        m_secondsLeft -= Time.deltaTime;
    }
}
