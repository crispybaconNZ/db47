using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteractive : Interactive
{
    private int _totalWoodReceived = 0;

    public override void interact(Player player) {
        // Debug.Log("Interacting with the machine!");
        if (player.CurrentWood > 0) {
            Debug.Log($"Feeding {player.CurrentWood} to the machine!");
            _totalWoodReceived += player.CurrentWood;
            player.CurrentWood = 0;
            Debug.Log($"Fed {_totalWoodReceived} to the machine so far!");

        }
    }
}
