using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour {
    private float countdown = 5f;
    private bool done = false;

    public bool IsDone() => done;

    void Update() {
        countdown -= Time.deltaTime;
        done = (countdown <= 0f);
    }
}
