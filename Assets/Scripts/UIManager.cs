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
    [SerializeField] private Needle _needle;
    private Queue<string> _messages;

    // Start is called before the first frame update
    void Start() {
        _carryText.text = "Carrying: nothing";
        _messagePanel.SetActive(false);
        if (_needle == null) { _needle = GameObject.Find("Needle").GetComponent<Needle>(); }
        _messages = new Queue<string>();
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

    public void Clear() => _messages.Clear();

    public void UpdateNeedle(float percent) {
        percent = Mathf.Clamp(percent, 0f, 100f);
        _needle.SetTargetPercent(percent);
    }
}
