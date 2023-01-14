using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IDoor
{
    public EventHandler OnOpenDoor;

    [SerializeField]
    private GameObject DoorPrefab;

    [SerializeField]
    private bool IsLocked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("OpenDoor")]
    public void Open()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("IsLocked", IsLocked);

        animator.SetTrigger("OpenDoor");
    }
}
