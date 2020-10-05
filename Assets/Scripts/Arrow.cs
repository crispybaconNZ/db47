using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The arrow helps navigate by always pointing towards the Machine

public class Arrow : MonoBehaviour {
    [SerializeField] private GameObject _machine;

    private void Awake() {
        if (_machine == null) { _machine = GameObject.Find("abrams_machine"); }
    }

    void Update() {
        // rotate arrow to face the machine
        transform.LookAt(_machine.transform.position);
    }
}
