using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDoor : MonoBehaviour
{
    [SerializeField]
    private RoomDifficulty m_difficulty;

    private void OnCollisionEnter(Collision collision)
    {
        var fp = collision.gameObject.GetComponent<FirstPersonController>();

        if (fp != null)
        {
            RoomManager.Instance.LoadNewRoom(m_difficulty);
        }
    }
}
