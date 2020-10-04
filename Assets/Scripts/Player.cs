using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _maxWood;
    private UIManager _uiManager;
    private int _currentWood;
    private int _currentStone;

    public int CurrentWood {
        get { return _currentWood;  } 
        set {
            _currentWood = value;
            _uiManager.UpdateCarryMessage(this);
        }
    }

    public int CurrentStone {
        get { return _currentStone; }
        set {
            _currentStone = value;
            _uiManager.UpdateCarryMessage(this);
        }
    }

    // Start is called before the first frame update
    void Start() {
        _currentWood = 0;
        _currentStone = 0;
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
