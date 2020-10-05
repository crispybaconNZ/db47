using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Demand {
    private int _wood;
    private int _stone;

    public int Wood { get { return _wood; } set { _wood = Mathf.Clamp(value, 0, int.MaxValue); } }
    public int Stone { get { return _stone; } set { _stone = Mathf.Clamp(value, 0, int.MaxValue); } }

    public Demand() {
        _wood = 0;
        _stone = 0;
    }
    public override string ToString() {
        if (_wood + _stone == 0) {
            return "The machine is satiated... for now";
        }

        string s = "The Machine demands ";

        if (_wood > 0) { 
            s = s + $"{_wood} wood "; 
            if (_stone > 0) { s = s + "and "; }
        }
        if (_stone > 0) {
            s = s + $"{_stone} stone";
        }

        return s;
    }

    public static Demand GenerateDemand() {
        Demand d = new Demand();
        d._wood = Random.Range(5, 20);
        d._stone = Random.Range(5, 20);

        return d;
    }

    public bool DemandMet() => _wood + _stone == 0;
}
