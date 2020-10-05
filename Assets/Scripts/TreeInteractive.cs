using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractive : Interactive {
    [SerializeField] private int _woodLeft; // amount of wood left in this tree
    private UIManager _uiManager;

    public override void interact(Player player) {
        if (player.CurrentWood < player.MaxWood) {
            _woodLeft--;
            player.CurrentWood += 1;
        } else {
            _uiManager.ShowMessage($"You cannot carry more than {player.MaxWood} wood");
        }

        if (_woodLeft == 0) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _woodLeft = Random.Range(15, 25);
        _uiManager = GameObject.FindObjectOfType<UIManager>();          
    }

    // Update is called once per frame
    void Update() {
        
    }
}
