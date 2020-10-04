using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MachineInteractive : Interactive {
    // percentages
    private const float DANGER_ZONE_BELOW = 6f; // machine in danger of exploding soon!
    private const float MIN_OPTIMAL = 13f;
    private const float MAX_OPTIMAL = 74f;
    private const float SLEEP_ZONE_ABOVE = 93f; // machine may go to sleep

    [SerializeField] private float _satiationDegradationRate = 1;

    private int _totalWoodReceived = 0;
    private int _totalStoneReceived = 0;
    private UIManager _uiManager;
    [SerializeField] private float machineSatiation;
    private bool _warningGiven = false;

    private Demand _currentDemand = null;

    private void Start() {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _uiManager.UpdateNeedle(machineSatiation);
    }

    public override void interact(Player player) {
        if (player.CurrentWood > 0 || player.CurrentStone > 0) {
            _totalWoodReceived += player.CurrentWood;
            _totalStoneReceived += player.CurrentStone;
            machineSatiation += player.CurrentWood + player.CurrentStone;
            _uiManager.UpdateNeedle(machineSatiation);
            _uiManager.ShowMessage($"Feeding {player.CurrentWood} wood and {player.CurrentStone} stone to the machine!");
            _uiManager.ShowMessage($"Fed {_totalWoodReceived} wood and {_totalStoneReceived} stone to the machine so far!");

            if (CheckDemandMet(player.CurrentWood, player.CurrentStone)) {
                _currentDemand = null;
                _uiManager.HideMachineDemand();
            }
            player.CurrentWood = 0;
            player.CurrentStone = 0;
            _uiManager.UpdateCarryMessage(player);
        }
    }

    private bool CheckDemandMet(int wood, int stone) => wood >= _currentDemand.Wood && stone >= _currentDemand.Stone;

    private void Update() {
        machineSatiation -= _satiationDegradationRate * Time.deltaTime;
        _uiManager.UpdateNeedle(machineSatiation);

        if (machineSatiation < DANGER_ZONE_BELOW && !_warningGiven) {
            _uiManager.ShowMessage("The machine is in danger of exploding!");
            _warningGiven = true;
        } else if (machineSatiation > SLEEP_ZONE_ABOVE && !_warningGiven) {
            _uiManager.ShowMessage("The machine may go to sleep");
            _warningGiven = true;
        } else if (machineSatiation >= DANGER_ZONE_BELOW && machineSatiation <= SLEEP_ZONE_ABOVE) {
            // clear the warning flag so that future warnings can be given            
            _warningGiven = false;
        }

        if (_currentDemand == null) {
            _currentDemand = Demand.GenerateDemand();
            _uiManager.SetMachineDemandText(_currentDemand.ToString());
            Debug.Log($"Current demand: {_currentDemand}");
        }
    }
}
