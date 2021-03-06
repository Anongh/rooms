﻿using UnityEngine;

public sealed class ControllerRotate : ControllerInteraction {
    [SerializeField] private float _yawSpeed = 90;
    [SerializeField] private float _pitchSpeed = 60;
    [SerializeField] private float _minX = -90, _maxX = 0;

//    private bool _isFocused;

    private void Update() {
        if (!IsFocused) return;

        var yawInput = Input.GetAxis("Xbox RStick X");
        var pitchInput = Input.GetAxis("Xbox RStick Y");

        var localRotation = transform.localEulerAngles;
        localRotation.y += yawInput * _yawSpeed * Time.deltaTime;
        localRotation.x += pitchInput * _pitchSpeed * Time.deltaTime;
        localRotation.x = Mathf.Clamp(localRotation.x, _minX, _maxX);
        transform.localEulerAngles = localRotation;
    }

//    private void OnTriggerEnter(Collider other) {
//        if (other.CompareTag("Player")) {
//            _isFocused = true;
//        }
//    }
//
//    private void OnTriggerExit(Collider other) {
//        if (other.CompareTag("Player")) {
//            _isFocused = false;
//        }
//    }
}
