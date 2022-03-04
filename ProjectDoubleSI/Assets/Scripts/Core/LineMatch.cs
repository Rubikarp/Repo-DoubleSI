using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LineMatch
{
    public string name = "Line X";
    public List<GameTile> matchingTile = new List<GameTile>();

    public int Number { get { return matchingTile.Count; } }
}
