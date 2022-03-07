using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Match3Manager : MonoBehaviour
{
    [Header("Info")]
    public List<LineMatch> foundMatchs = new List<LineMatch>();

    [Header("Dependancy")]
    public GameGrid grid;
    public GameObject linePrefab;
    [Header("Event")]
    public UnityEvent onMatch;

    [NaughtyAttributes.Button]
    public void LookForMatch()
    {
        foreach (var match in foundMatchs)
        {
            match.Clear();
        }
        foundMatchs.Clear();
        foundMatchs = new List<LineMatch>();
        //foundMatchs.TrimExcess();
        //GC.Collect();

        LineMatch newMatch;
        //Toute les colonnes
        for (int x = 0; x < grid.size.x; x++)
        {
            for (int y = 0; y < grid.size.y; y++)
            {
                newMatch = CheckItemLineFrom(true, grid.GetTile(x, y), Vector2Int.up);

                if (newMatch == null) { continue; }

                y += newMatch.Number - 1;
                foundMatchs.Add(newMatch);
            }
        }
        //Toute les lignes
        for (int y = 0; y < grid.size.y; y++)
        {
            for (int x = 0; x < grid.size.x; x++)
            {
                newMatch = CheckItemLineFrom(false, grid.GetTile(x, y), Vector2Int.right);

                if (newMatch == null) { continue; }

                x += newMatch.Number - 1;
                foundMatchs.Add(newMatch);
            }
        }
    }
    public void Touch(GameTile tileTouched)
    {
        foundMatchs[0].matchingTile.Contains(tileTouched);
        List<LineMatch> lineMatched = foundMatchs.Where(line => line.matchingTile.Contains(tileTouched)).ToList();

        if (lineMatched.Count > 0)
        {
            //Score
            //Mana

            foreach (var tile in lineMatched[0].matchingTile)
            {
                Destroy(tile.item.gameObject);
                tile.item = null;
            }

            onMatch?.Invoke();
        }
    }
    public LineMatch CheckItemLineFrom(bool vert, GameTile testedTile, Vector2Int dir)
    {
        //TODO : Le faire plus proprement
        FoodSCO food = testedTile.item.Food;
        LineMatch newMatch = null;

        if (food == grid.GetFood(testedTile.gridPos + dir * 1)
         && food == grid.GetFood(testedTile.gridPos + dir * 2))
        {
            //Match3 Confirmed
            newMatch = new LineMatch(vert,vert?testedTile.gridPos.x:testedTile.gridPos.y, linePrefab, transform);
            newMatch.matchingTile.Add(testedTile);
            newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * 1));
            newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * 2));

            if (food == grid.GetFood(testedTile.gridPos + dir * 3))
            {
                newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * 3));

                if (food == grid.GetFood(testedTile.gridPos + dir * 4))
                {
                    newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * 4));
                }
            }
            newMatch.UpdateLine();
        }
        return newMatch;
    }

}
