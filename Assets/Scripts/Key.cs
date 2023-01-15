using UnityEngine;

public class Key : MonoBehaviour, IPlayerProximityTrigger
{
    [SerializeField]
    private bool m_isBigKey = false;

    public void Trigger()
    {
        PlayerInventory.Instance.AddKey(isBigKey: m_isBigKey);
        Destroy(gameObject);
    }
}
