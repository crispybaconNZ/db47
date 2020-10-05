using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private MachineInteractive _machine;
    private Player _player;
    private UIManager _uiManager;
    [SerializeField] private Explosion _explosion;
    
    void Awake()  {
        _machine = GameObject.FindObjectOfType<MachineInteractive>();
        _player = GameObject.FindObjectOfType<Player>();
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (_machine.HasExploded()) {
            _machine.ExplodeMachine();
            _uiManager.ShowGameOver();
            _explosion.gameObject.SetActive(true);
        }

        if (_explosion != null && _explosion.IsDone()) {
            _explosion.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }
}
