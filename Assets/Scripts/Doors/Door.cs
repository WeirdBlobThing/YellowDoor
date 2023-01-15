using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IDoor, IPlayerProximityTrigger
{
    public EventHandler OnOpenDoor;

    [SerializeField]
    private bool IsLocked;

    [SerializeField]
    private RoomDifficulty m_difficulty;

    [ContextMenu("OpenDoor")]
    public void Open()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("IsLocked", IsLocked);

        animator.SetTrigger("OpenDoor");
    }

    public void Trigger()
    {
        StartCoroutine(OpenAndTrigger());
    }

    private IEnumerator OpenAndTrigger()
    {
        Open();

        // TODO: This should wait until the animation is complete!
        yield return new WaitForSeconds(0.75f);

        RoomManager.Instance.LoadNewRoom(m_difficulty);
    }
}
