using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _maxWood;
    public int CurrentWood { get; set; }

    // Start is called before the first frame update
    void Start() {
        CurrentWood = 0;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
