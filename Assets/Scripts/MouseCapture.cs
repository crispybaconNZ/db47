using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCapture : MonoBehaviour {
    [SerializeField] private GameObject _markerPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _interactionDistance; // player must at least this close to interact with something

    void Update() {

        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.name == "Ground") {
                    Vector3 pos = hit.point;
                    Instantiate(_markerPrefab, pos, Quaternion.identity);
                } else if (hit.collider.GetComponentsInChildren<Interactive>().Length > 0) {
                    // there's an interact in here....
                    Interactive child = hit.collider.GetComponentsInChildren<Interactive>()[0];
                    float distance = Vector3.Distance(transform.position, hit.point);
                    if (distance <= _interactionDistance) {
                        child.interact();
                    } else {
                        Debug.Log($"Too far! ({distance})");
                    }
                } else {
                    Debug.Log("Not interactive");
                }
            }
        }
    }
}
