using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IPlayerProximityTrigger
{
    [SerializeField]
    private bool IsBigLock = false;

    [SerializeField]
    public bool IsLocked = true;

    [SerializeField]
    private Rigidbody UpperLock;

    [SerializeField]
    private Rigidbody LowerLock;

    [SerializeField]
    float LockExplosionScale = 1f;


    public void Trigger()
    {
        AttemptUnlock();
    }
    public bool AttemptUnlock()
    {
        Debug.Log($"{PlayerInventory.Instance.KeyCount(IsBigLock)} Keys");
        if (PlayerInventory.Instance.KeyCount(IsBigLock) > 0)
        {
            IsLocked = false;
            PlayerInventory.Instance.RemoveKey(IsBigLock);
            //UpperLock.isKinematic = false;
            //LowerLock.isKinematic = false;
            UpperLock.AddForce(Vector3.up * LockExplosionScale, ForceMode.Impulse);
            LowerLock.AddForce(Vector3.down * LockExplosionScale, ForceMode.Impulse);
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
