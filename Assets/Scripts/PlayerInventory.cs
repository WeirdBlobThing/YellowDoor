using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private int m_bigKeys;

    private int m_smallKeys = 1;

    private void Awake()
    {
        Instance = this;
    }

    //public int SmallKeyCount()
    //{
    //    return m_smallKeys;
    //}

    //public int BigKeyCount()
    //{
    //    return m_bigKeys;
    //}

    public int KeyCount(bool isBigKey)
    {
        if (isBigKey)
        {
            return m_bigKeys;
        }
        else
        {
            return m_smallKeys;
        }
    }

    public void AddKey(bool isBigKey)
    {
        if (isBigKey)
        {
            m_bigKeys++;
        }
        else
        {
            m_smallKeys++;
        }
    }

    public void RemoveKey(bool isBigKey)
    {
        if (isBigKey)
        {
            m_bigKeys--;
        }
        else
        {
            m_smallKeys--;
        }
    }
}
