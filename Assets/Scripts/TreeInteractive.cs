using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractive : Interactive {
    [SerializeField] private int _woodLeft; // amount of wood left in this tree

    public override void interact(Player player) {
        _woodLeft--;
        player.CurrentWood += 1;

        Debug.Log($"Wood left in this tree: {_woodLeft}");

        if (_woodLeft == 0) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _woodLeft = Random.Range(15, 25);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
