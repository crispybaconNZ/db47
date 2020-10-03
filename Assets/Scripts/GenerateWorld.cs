using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private int numTrees = 200;
    [SerializeField] private GameObject _treePrefab;

    private List<GameObject> _trees;
    private Transform treeParent;

    void Start() {
        treeParent = transform.Find("TreeCollection");

        if (_treePrefab) {
            _trees = new List<GameObject>(numTrees);

            for (int index = 0; index < numTrees; index++) {
                Vector3 pos = new Vector3(Random.Range(400f, 600f), 0f, Random.Range(200f, 300f));
                GameObject newTree = Instantiate(_treePrefab, pos, Quaternion.identity);
                newTree.transform.SetParent(treeParent);
            }
        } else {
            Debug.Log("No tree prefab!");                
        }
    }


}
