using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteractive : Interactive
{
    private int _totalWoodReceived = 0;
    private UIManager _uiManager;

    private void Start() {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }
    public override void interact(Player player) {
        if (player.CurrentWood > 0) {
            _totalWoodReceived += player.CurrentWood;
            _uiManager.ShowMessage($"Feeding {player.CurrentWood} to the machine! Fed {_totalWoodReceived} to the machine so far!");
            player.CurrentWood = 0;
        }
    }
}
