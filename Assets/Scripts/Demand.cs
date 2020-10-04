using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demand {
    private int _wood;
    private int _stone;

    public int Wood { get; set; }
    public int Stone { get; set; }

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
        while (d.Wood + d.Stone == 0) {
            d.Wood = Random.Range(0, 10);
            d.Stone = Random.Range(0, 10);
            Debug.Log($"{d._wood} wood, {d._stone} stone");
        }

        return d;
    }
}
