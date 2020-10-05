using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Demand {
    private int _wood;
    private int _stone;

    private const int MAX_WOOD_DEMAND = 20;
    private const int MIN_WOOD_DEMAND = 10;
    private const int MAX_STONE_DEMAND = 10;
    private const int MIN_STONE_DEMAND = 5;


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

    public static Demand GenerateDemand(Player player=null) {
        Demand d = new Demand();
        int multiplier = player == null ? 1 : player.Level;

        d._wood = Random.Range(MIN_WOOD_DEMAND * multiplier, MAX_WOOD_DEMAND * multiplier);
        d._stone = Random.Range(MIN_STONE_DEMAND * multiplier, MAX_STONE_DEMAND * multiplier);

        return d;
    }

    public bool DemandMet() => _wood + _stone == 0;
}
