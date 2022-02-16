﻿
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    public float smoothSpeed = 0.04f;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);

        transform.position = newPos;
    }
}
