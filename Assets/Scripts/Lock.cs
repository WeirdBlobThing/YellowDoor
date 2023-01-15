using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IPlayerProximityTrigger
{
    [SerializeField]
    private bool IsBigLock = false;

    [SerializeField]
    public bool IsLocked = true;


    public void Trigger()
    {
        AttemptUnlock();
    }
    public bool AttemptUnlock()
    {
        if (PlayerInventory.Instance.KeyCount(IsBigLock) > 0)
        {
            IsLocked = false;
            PlayerInventory.Instance.RemoveKey(IsBigLock);
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (IsBigLock)
        {
            transform.localScale *= 2;
        }
    }

}
