using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour {
    [SerializeField] private Vector3 _scaleBy;
    private bool _done = false;

    private void Start() {
        if(_scaleBy == null) { _scaleBy = new Vector3(1f, 1f, 1f); }
    }

    void Detonate() {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        transform.localScale += _scaleBy;

        if (transform.localScale.x > 200) { _done = true; }
    }

    public bool IsDone() => _done;
}
