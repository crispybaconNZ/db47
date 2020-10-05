using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The arrow helps navigate by always pointing towards the Machine

public class Arrow : MonoBehaviour {
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _machine;

    private void Awake() {
        if (_player == null) { _player = GameObject.FindObjectOfType<Player>(); }
        if (_machine == null) { _machine = GameObject.Find("abrams_machine"); }
    }
    void Update() {
        // find angle between player and machine
        Vector3 dir = _player.transform.position - _machine.transform.position;
        dir = dir.normalized;

        // rotate arrow to face the machine
        transform.LookAt(_machine.transform.position);
    }
}
