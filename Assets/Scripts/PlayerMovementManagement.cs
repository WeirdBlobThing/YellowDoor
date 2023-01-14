using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManagement : MonoBehaviour
{
    public float speed;

    public float joystickSpeed;

    void Update()
    {
        Vector3 pos = transform.position;
        float normalizedSpeed = speed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal") * joystickSpeed * Time.deltaTime;

        float VerticalSpeed = Input.GetAxis("Vertical") * joystickSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.W))
        {
            pos.z += normalizedSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.z -= normalizedSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += normalizedSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= normalizedSpeed;
        }

        pos.x += horizontalInput;
        pos.z += VerticalSpeed;

        transform.position = pos;
    }
}
