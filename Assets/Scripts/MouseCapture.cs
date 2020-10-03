using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCapture : MonoBehaviour {
    [SerializeField] private GameObject _markerPrefab;
    [SerializeField] private Camera _camera;

    void Update() {

        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left mouse button clicked");
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.name == "Ground") {
                    Vector3 pos = hit.point;
                    Instantiate(_markerPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
