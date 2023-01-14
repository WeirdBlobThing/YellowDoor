using TMPro;
using UnityEngine;

public class DebugHourglass : MonoBehaviour
{

    [SerializeField]
    private TMP_Text m_timer;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        int minutes = Mathf.FloorToInt(TimeManager.Instance.GetTimeInSeconds() / 60);
        int seconds = Mathf.FloorToInt(TimeManager.Instance.GetTimeInSeconds() % 60);


        // Probably a ToString that left pads zeros but :shrug:
        string minutesString = "0";
        if (minutes > 0)
        {
            minutesString = minutes.ToString();
        }

        string secondsString = "00";
        if (seconds > 0)
        {
            if (seconds > 9)
            {
                secondsString = seconds.ToString();
            }
            else
            {
                secondsString = string.Format("0{0}", seconds);
            }
        }

        m_timer.text = string.Format("{0}:{1}", minutesString, secondsString);
    }
}
