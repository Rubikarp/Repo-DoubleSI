using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LineMatch
{
    public string name = "Line X";
    public List<GameTile> matchingTile = new List<GameTile>();
    
    [Header("Line")]
    public LineRenderer visual;

    public LineMatch(bool vertical,int index, GameObject linePrefab, Transform parent)
    {
        matchingTile = new List<GameTile>();
        name = vertical ? "Column_" + index : "Line_" + index;
        visual = MonoBehaviour.Instantiate(linePrefab, parent).GetComponent<LineRenderer>();
        UpdateLine();
    }

    public void Clear()
    {
        if (visual != null)
        {
            GameObject.Destroy(visual.gameObject);
        }
    }
    
    public void UpdateLine()
    {
        visual.positionCount = matchingTile.Count;
        IEnumerable<Vector3> poses = matchingTile.Select(x => x.worldPos);
        visual.SetPositions(poses.ToArray());
    }
    public int Number { get { return matchingTile.Count; } }
}
