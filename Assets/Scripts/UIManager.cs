using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text _carryText;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private Text _messageText;
    private float time_to_live = 0f;
    [SerializeField] private float _messageDisplayTime = 5f; // seconds

    // Start is called before the first frame update
    void Start() {
        _carryText.text = "Carrying: nothing";
        _messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (time_to_live > 0f) {
            time_to_live -= Time.deltaTime;
        }

        if (time_to_live <= 0f) {
            _messageText.text = "";
            _messagePanel.SetActive(false);
            time_to_live = 0f;
        }
    }

    public string CarryText {
        get { return _carryText.text; }
        set { _carryText.text = value; }
    }

    public void ShowMessage(string text) {
        time_to_live = _messageDisplayTime;
        _messageText.text = text;
        _messagePanel.SetActive(true);
    }
}
