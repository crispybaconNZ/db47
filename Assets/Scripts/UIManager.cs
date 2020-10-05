using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text _carryText;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private Text _messageText;
    [SerializeField] private GameObject _machineDemandPanel;
    [SerializeField] private Text _machineDemandText;
    [SerializeField] private Text _gameOver;

    private float time_to_live = 0f;
    [SerializeField] private float _messageDisplayTime = 5f; // seconds
    [SerializeField] private Needle _needle;
    private Queue<string> _messages;

    // Start is called before the first frame update
    void Start() {
        _messages = new Queue<string>();
        if (_messagePanel == null) { _messagePanel = GameObject.Find("MessagePanel"); }
        if (_messageText == null) { _messageText = GameObject.Find("MessageText").GetComponent<Text>(); }
        if (_needle == null) { _needle = GameObject.Find("Needle").GetComponent<Needle>(); }
        if (_carryText == null) { _carryText = GameObject.Find("CarryingText").GetComponent<Text>(); }
        if (_machineDemandPanel == null) { _machineDemandPanel = GameObject.Find("MachineDemand"); }
        if (_machineDemandText == null) { _machineDemandText = GameObject.Find("MachineDemandText").GetComponent<Text>(); }
        if (_gameOver == null) { _gameOver = GameObject.Find("GameOverText").GetComponent<Text>(); }

        _carryText.text = "Carrying: nothing";
        _gameOver.text = "GAME OVER!";
        _messagePanel.SetActive(false);        
    }

    // Update is called once per frame
    void Update() {
        if (time_to_live > 0f) {
            time_to_live -= Time.deltaTime;
            _messagePanel.SetActive(true);
        } else {
            if (_messages.Count > 0) {
                time_to_live = _messageDisplayTime;
                _messageText.text = _messages.Dequeue();
                _messagePanel.SetActive(true);
            } else {
                _messageText.text = "";
                _messagePanel.SetActive(false);
                time_to_live = 0f;
            }
        }
    }

    public string CarryText {
        get { return _carryText.text; }
        set { _carryText.text = value; }
    }

    public void ShowMessage(string text) => _messages.Enqueue(text);

    public void ShowMessage(string text, bool priority) {
        if (priority) {
            _messages.Clear();
            _messages.Enqueue(text);
            time_to_live = 0f;
        } else {
            ShowMessage(text);
        }
    }

    public void Clear() => _messages.Clear();

    public void UpdateNeedle(float percent) {
        percent = Mathf.Clamp(percent, 0f, 100f);
        _needle.SetTargetPercent(percent);
    }

    public void UpdateCarryMessage(Player player) {
        CarryText = $"Carrying: {player.CurrentWood} wood; {player.CurrentStone} stone";
    }

    public void SetMachineDemandText(string text) {
        _machineDemandText.text = text;
        _machineDemandPanel.SetActive(true);
    }

    public void HideMachineDemand() => _machineDemandPanel.SetActive(false);

    public void ShowGameOver() => _gameOver.gameObject.SetActive(true);
}
