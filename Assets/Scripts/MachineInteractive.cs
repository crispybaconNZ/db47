using System.CodeDom;
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
    [SerializeField] private float _woodSatiationMultiplier = 1;
    [SerializeField] private float _stoneSatiationMultiplier = 1;

    private UIManager _uiManager;
    [SerializeField] private float machineSatiation;
    private bool _warningGiven = false;
    private Demand _currentDemand = null;

    private const float MAX_DEMAND_DELAY = 20f;
    private const float MIN_DEMAND_DELAY = 2f;
    private float timeTillNextDemand = 0f;
    private bool _exploded = false;

    private int times_in_danger = 0;    // number of times machine has gone into the danger zone

    private void Start() {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _uiManager.UpdateNeedle(machineSatiation);
    }

    public override void interact(Player player) {
        // player interacts with machine to drop resources

        // can't remove more than the player has
        int wood_to_remove = player.CurrentWood;
        int stone_to_remove = player.CurrentStone;

        // remove resources from the player
        player.CurrentWood -= wood_to_remove;
        player.CurrentStone -= stone_to_remove;

        if (_currentDemand == null) {
            // no demand at the moment
            _uiManager.ShowMessage("The Machine seems satiated ... for now ...");
        } else {
            // and remove from the current demand
            _currentDemand.Wood -= wood_to_remove;
            _currentDemand.Stone -= stone_to_remove;

            if (CheckDemandMet()) {
                // demand has been met
                _uiManager.ShowMessage("The Machine's demands have been met, temporarily");
                _uiManager.HideMachineDemand();
                _currentDemand = null;
            } else {
                // demand still not fulfilled
                _uiManager.UpdateCarryMessage(player);
                _uiManager.SetMachineDemandText(_currentDemand.ToString());
            }
        }

        // satiate the machine
        machineSatiation += (wood_to_remove * _woodSatiationMultiplier) + (stone_to_remove * _stoneSatiationMultiplier);

        // update UI elements
        _uiManager.UpdateCarryMessage(player);
        
    }

    private bool CheckDemandMet() => _currentDemand.Wood + _currentDemand.Stone == 0;

    private void Update() {
        if (_exploded) {
            return;
        }

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
            timeTillNextDemand -= Time.deltaTime;
            if (timeTillNextDemand <= 0) {
                _currentDemand = Demand.GenerateDemand();
                _uiManager.SetMachineDemandText(_currentDemand.ToString());
                timeTillNextDemand = Random.Range(MIN_DEMAND_DELAY, MAX_DEMAND_DELAY);
            }
        }
    }

    public bool HasExploded() {
        // returns true of the machine has exploded
        if (machineSatiation > DANGER_ZONE_BELOW) { return false; } // no danger of machine exploding
        times_in_danger++;

        // the chance of the machine exploding is proportional to (a) how far into the danger-zone it has reached and (b) how many times
        // it's got into the danger-zone
        float chance_of_exploding = (DANGER_ZONE_BELOW - machineSatiation) / DANGER_ZONE_BELOW; // 0% if just on the DANGER_ZONE_BELOW line, 100% if at zero
        chance_of_exploding = Mathf.Clamp(chance_of_exploding * times_in_danger, 0f, 1f);

        return Random.Range(0f, 1f) < chance_of_exploding;
    }

    public void ExplodeMachine() {
        _exploded = true;
        _uiManager.ShowMessage("The machine has exploded!", true);
    }
}
