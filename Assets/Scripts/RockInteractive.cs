using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractive : Interactive {
    private int _stoneLeft = 20;
    private UIManager _uiManager;

    public override void interact(Player player) {
        _stoneLeft--;
        player.CurrentStone += 1;

        // _uiManager.ShowMessage($"Stone left in this rock: {_stoneLeft}");

        if (_stoneLeft == 0) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _stoneLeft = Random.Range(15, 25);
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
