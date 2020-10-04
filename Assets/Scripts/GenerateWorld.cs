using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private int numTrees = 200;
    [SerializeField] private int numRocks = 200;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;

    private Transform treeParent;
    private Transform rockParent;

    void Start() {
        treeParent = transform.Find("TreeCollection");
        rockParent = transform.Find("RockCollection");

        GeneratePrefabs("tree", _treePrefab, numTrees, treeParent);
        GeneratePrefabs("rock", _rockPrefab, numRocks, rockParent);
    }

    private void GeneratePrefabs(string name, GameObject _prefab, int count, Transform parent=null) {
        if (_prefab) {            
            for (int index = 0; index < count; index++) {
                Vector3 pos = new Vector3(Random.Range(0f, 1000f), 0f, Random.Range(0f, 1000f));
                GameObject newItem = Instantiate(_prefab, pos, Quaternion.identity);
                if (parent != null) { newItem.transform.SetParent(parent); }
            }
        } else {
            Debug.Log($"No {name} prefab found!");
        }
    }

}
