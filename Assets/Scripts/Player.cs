using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _maxWood;
    private UIManager _uiManager;
    private int _currentWood;

    public int CurrentWood {
        get { return _currentWood;  } 
        set {
            _currentWood = value;
            UpdateUI();
        }
    }

    // Start is called before the first frame update
    void Start() {
        _currentWood = 0;
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void UpdateUI() {
        if (_uiManager == null) { return; }

        _uiManager.CarryText = $"Carrying: {CurrentWood} wood";
    }
}
