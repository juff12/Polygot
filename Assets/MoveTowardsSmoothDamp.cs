using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class MoveTowardsSmoothDamp : MonoBehaviour
{
    public float maxMoveSpeed = 100;
    public float smoothTime = 0.01f;
    private Vector2 currentVelocity;
    public Rigidbody2D selectedObject;
    public Vector2 target;

    void Start()
    {
        selectedObject.freezeRotation = true;
        selectedObject.gravityScale = 0.0f;
    }

    void OnMouseDown()
    {
        selectedObject.WakeUp();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = new Vector2(mousePosition.x, selectedObject.position.y);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UnityEngine.Debug.Log("Pressed button");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new Vector2(mousePosition.x, selectedObject.position.y);
            selectedObject.position = Vector2.SmoothDamp(selectedObject.position, target, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject.position = target;
            selectedObject.freezeRotation = false;
            selectedObject.gravityScale = 1.0f;
        }
    }
}
