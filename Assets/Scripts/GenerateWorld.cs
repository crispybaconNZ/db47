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

        if (_treePrefab == null) { _treePrefab = null; }
        if (_rockPrefab == null) { _rockPrefab = null; }

        Vector3 rockTranslation = new Vector3(0, 0.9f, 0);
        GeneratePrefabs("tree", _treePrefab, numTrees, treeParent);
        GeneratePrefabs("rock", _rockPrefab, numRocks, rockTranslation, rockParent, true);
    }

    private void GeneratePrefabs(string name, GameObject _prefab, int count, Vector3 _translate, Transform parent = null, bool rand_rotation=false) {
        if (_prefab) {
            for (int index = 0; index < count; index++) {
                Vector3 pos = new Vector3(Random.Range(0f, 1000f), 0f, Random.Range(0f, 1000f));
                GameObject newItem = Instantiate(_prefab, pos, Quaternion.identity);
                if (!rand_rotation) {
                    newItem.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
                }
                newItem.transform.Translate(_translate);
                if (parent != null) { newItem.transform.SetParent(parent); }
            }            
        } else {
            Debug.Log($"No {name} prefab found!");
        }

        
    }

    private void GeneratePrefabs(string name, GameObject _prefab, int count, Transform parent = null) {        
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
