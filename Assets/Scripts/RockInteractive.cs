using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractive : Interactive {
    private int _stoneLeft = 20;
    private UIManager _uiManager;

    public override void interact(Player player) {
        if (player.CurrentStone < player.MaxStone) {
            _stoneLeft--;
            player.CurrentStone += 1;
        } else {
            _uiManager.ShowMessage($"You cannot carry more than {player.MaxStone} stone");
        }

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
