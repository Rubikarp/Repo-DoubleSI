using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LineMatch
{
    public string name = "Line X";
    public List<GameTile> matchingTile = new List<GameTile>();

    public List<FoodSCO> ingredients;
    public bool isRecipe = false;
    public RecipeSCO recipe;

    [Header("Line")]
    GameObject[] visuPrefab;
    public LineRenderer visual;
    public List<GameObject> vfx = new List<GameObject>();

    public LineMatch(bool vertical, int index, GameObject[] visuPrefab, Transform parent)
    {
        name = vertical ? "Column_" + index : "Line_" + index;

        matchingTile = new List<GameTile>();
        this.visuPrefab = visuPrefab;

        visual = MonoBehaviour.Instantiate(visuPrefab[0], parent).GetComponent<LineRenderer>();
        UpdateLine();
    }
    public LineMatch(bool vertical, int index, GameObject[] visuPrefab, Transform parent, RecipeSCO recipe)
    {
        name = vertical ? "Column_" + index : "Line_" + index;

        matchingTile = new List<GameTile>();
        isRecipe = true;
        this.recipe = recipe;
        this.visuPrefab = visuPrefab;

        visual = MonoBehaviour.Instantiate(visuPrefab[0], parent).GetComponent<LineRenderer>();
        UpdateLine();
    }

    public void Clear()
    {
        if (visual != null)
        {
            visual.transform.DeleteChildren();
            GameObject.Destroy(visual.gameObject);
        }
    }
    public void End()
    {
        if (visual != null)
        {
            for (int i = 0; i < matchingTile.Count; i++)
            {
                MonoBehaviour.Instantiate(visuPrefab[3], matchingTile[i].worldPos, Quaternion.Euler(-90, 0, 0));
            }
            visual.transform.DeleteChildren();
            GameObject.Destroy(visual.gameObject);
        }
    }

    public void UpdateLine()
    {
        //Ingredients
        ingredients = matchingTile.Select(tile => tile.item.Food).ToList();

        GameObject temp;
        visual.transform.DeleteChildren();
        for (int i = 0; i < matchingTile.Count; i++)
        {
            temp = MonoBehaviour.Instantiate(visuPrefab[isRecipe ? 1 : 2],
                                             matchingTile[i].worldPos, 
                                             Quaternion.Euler(-90,0,0), 
                                             visual.transform);
            vfx.Add(temp);
        }

        //Visual
        visual.positionCount = matchingTile.Count;
        IEnumerable<Vector3> poses = matchingTile.Select(x => x.worldPos);
        visual.SetPositions(poses.ToArray());
    }
    public int Lenght { get { return matchingTile.Count; } }
}
