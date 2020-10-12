using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {
    [SerializeField] private float _rotateSpeed = 1.0f;
    private CinemachineFreeLook _freeLook;

    void Start() {
        _freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Comma) || Input.GetKey(KeyCode.Q)) {
            _freeLook.m_XAxis.Value += _rotateSpeed;
        } else if (Input.GetKey(KeyCode.Period) || Input.GetKey(KeyCode.E)) {
            _freeLook.m_XAxis.Value -= _rotateSpeed;
        }
    }
}
