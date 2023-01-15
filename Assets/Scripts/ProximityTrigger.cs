using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_activationKeyCode = KeyCode.None;

    private IPlayerProximityTrigger m_playerProximityTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        var fp = collision.gameObject.GetComponent<FirstPersonController>();

        if (fp != null)
        {
            var proximityTrigger = gameObject.GetComponent<IPlayerProximityTrigger>();

            if (proximityTrigger != null)
            {
                m_playerProximityTrigger = proximityTrigger;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var fp = collision.gameObject.GetComponent<FirstPersonController>();

        if (fp != null)
        {
            var proximityTrigger = gameObject.GetComponent<IPlayerProximityTrigger>();

            if (proximityTrigger != null)
            {
                m_playerProximityTrigger = null;
            }
        }
    }

    private void Update()
    {
        if (m_playerProximityTrigger != null)
        {
            if (m_activationKeyCode != KeyCode.None && Input.GetKeyUp(m_activationKeyCode))
            {
                m_playerProximityTrigger.Trigger();
                m_playerProximityTrigger = null;
            }
            else if (m_activationKeyCode == KeyCode.None)
            {
                m_playerProximityTrigger.Trigger();
                m_playerProximityTrigger = null;
            }
        }
    }
}
