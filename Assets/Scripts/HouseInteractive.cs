using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInteractive : Interactive {
    private UIManager _uiManager;

    private void Start() {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    public override void interact(Player player) {
        _uiManager.ShowMessage("Nobody's home");
    }
}
