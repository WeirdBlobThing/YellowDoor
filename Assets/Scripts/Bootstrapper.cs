using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public static Bootstrapper Instance;

    [SerializeField]
    private GameObject[] m_prefabs;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            InitializePrefabs();
        }
    }

    private void InitializePrefabs()
    {
        foreach (var pfb in m_prefabs)
        {
            var go = Instantiate(pfb);
            go.transform.SetParent(transform);
        }
    }
}
