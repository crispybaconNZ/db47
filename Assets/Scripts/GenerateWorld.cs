using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private int numTrees = 20;
    [SerializeField] private GameObject _treePrefab;

    private List<GameObject> _trees;
    private Transform treeParent;

    void Start() {
        treeParent = transform.Find("TreeCollection");

        if (_treePrefab) {
            _trees = new List<GameObject>(numTrees);

            for (int index = 0; index < numTrees; index++) {
                Vector3 pos = new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f));
                GameObject newTree = Instantiate(_treePrefab, pos, Quaternion.identity);
                newTree.transform.SetParent(treeParent);
            }
        } else {
            Debug.Log("No tree prefab!");                
        }
    }


}
