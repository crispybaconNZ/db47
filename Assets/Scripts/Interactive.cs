using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour {
    // attach a subclass of this to a 3D object and implement interact()
    public abstract void interact();
}
