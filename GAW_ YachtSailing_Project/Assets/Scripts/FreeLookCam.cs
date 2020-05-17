using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FreeLookCam : MonoBehaviour
{
    public Vector2 mouseDelta { set; get; }

    [SerializeField] float RotateSpeed = 100f;
    float yaw, pitch;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += mouseDelta.x * RotateSpeed * Time.deltaTime;
        pitch -= mouseDelta.y * RotateSpeed * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -5, 60);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
