using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private bool IsBigLock = false;

    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        if(IsBigLock)
        {
            transform.localScale *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
