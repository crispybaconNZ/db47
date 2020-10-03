using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCapture : MonoBehaviour {
    [SerializeField] private GameObject _markerPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _interactionDistance; // player must at least this close to interact with something
    [SerializeField] private Player _player;

    private void Start() {
        if (_player == null) {
            _player = GameObject.FindObjectOfType<Player>();
        }        
    }
    void Update() {
        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse)) {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.name == "Ground") {
                    // clicked on the ground
                    // Vector3 pos = hit.point;
                    // Instantiate(_markerPrefab, pos, Quaternion.identity);
                } else if (hit.collider.GetComponentsInChildren<Interactive>().Length > 0) {
                    // there's an interact in here....
                    Interactive child = hit.collider.GetComponentsInChildren<Interactive>()[0];
                    Debug.Log($"{_player.name} interacting with {child.name}");

                    float distance = Vector3.Distance(transform.position, hit.point);
                    if (distance <= _interactionDistance) {                        
                        child.interact(_player);
                    } else {
                        // Debug.Log($"Too far away to interact ({distance})");
                    }
                } else if (hit.collider.tag == "Player") {
                    Player player = hit.collider.gameObject.GetComponent<Player>();
                    Debug.Log($"Player carrying {player.CurrentWood} wood");
                    
                } else {
                    // Debug.Log("Not an interactive");
                }
            }
        } else if (Input.GetMouseButtonDown((int)MouseButton.RightMouse)) {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.name == "Ground") {
                    // right-clicked on the ground
                    Vector3 pos = hit.point;
                    Instantiate(_markerPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
