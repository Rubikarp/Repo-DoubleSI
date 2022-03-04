using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Match3Manager : MonoBehaviour
{
    [Header("Info")]
    public List<LineMatch> foundMatchs = new List<LineMatch>();

    [Header("Dependancy")]
    public GameGrid grid;

    [NaughtyAttributes.Button]
    public void LookForMatch()
    {
        foundMatchs = new List<LineMatch>();
        LineMatch newMatch;
        //Toute les colonnes
        for (int x = 0; x < grid.size.x; x++)
        {
            for (int y = 0; y < grid.size.y; y++)
            {
                newMatch = CheckItemLineFrom(grid.GetTile(x, y), Vector2Int.up);

                if (newMatch == null) { continue; }

                y += newMatch.Number -1;
                foundMatchs.Add(newMatch);
            }
        }

        //Toute les lignes
        for (int y = 0; y < grid.size.y; y++)
        {
            for (int x = 0; x < grid.size.x; x++)
            {
                newMatch = CheckItemLineFrom(grid.GetTile(x, y), Vector2Int.right);

                if (newMatch == null) { continue; }

                x += newMatch.Number - 1;
                foundMatchs.Add(newMatch);
            }
        }
    }

    public LineMatch CheckItemLineFrom(GameTile testedTile, Vector2Int dir)
    {
        //TODO : Le faire plus proprement
        FoodSCO food = testedTile.item.Food;
        LineMatch newMatch = null;

        if (food == grid.GetFood(testedTile.gridPos + dir * 1)
         && food == grid.GetFood(testedTile.gridPos + dir * 2))
        {
            //Match3 Confirmed
            newMatch = new LineMatch();
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
        }
        return newMatch;
    }

}
