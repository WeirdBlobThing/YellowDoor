using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IDoor, IPlayerProximityTrigger
{
    public EventHandler OnOpenDoor;

    [SerializeField]
    private Lock Lock;

    [SerializeField]
    private RoomDifficulty m_difficulty;

    [ContextMenu("OpenDoor")]
    public void Open()
    {
        var animator = GetComponent<Animator>();

        animator.SetBool("IsLocked", Lock.IsLocked);

        animator.SetTrigger("OpenDoor");
    }

    public void Trigger()
    {
        StartCoroutine(OpenAndTrigger());
    }

    private IEnumerator OpenAndTrigger()
    {
        //No lock, already unlocked, or player unlocked by attempting to open
        if (Lock == null || Lock.IsLocked == false || Lock.AttemptUnlock())
        {
            Open();

            // TODO: This should wait until the animation is complete!
            yield return new WaitForSeconds(0.75f);

            RoomManager.Instance.LoadNewRoom(m_difficulty);
        }
    }
}
