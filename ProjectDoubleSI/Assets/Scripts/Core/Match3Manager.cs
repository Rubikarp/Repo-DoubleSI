using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MatchEvent : UnityEvent<LineMatch> { }

public class Match3Manager : MonoBehaviour
{
    [Header("Dependancy")]
    public GameGrid grid;
    [Tooltip("LineRender / VFX Recipe / VFX Ingredient")]
    public GameObject[] visuPrefab;

    [Header("Dependancy")]
    public PlayerHand player;

    [Header("Event")]
    public MatchEvent onMatch;
    public PowerEvent onRecipeMatch;
    [Header("Info")]
    public List<LineMatch> foundMatchs = new List<LineMatch>();

    private void Start()
    {
        LookForMatch();
    }

    public void Touch(GameTile tileTouched)
    {
        if (foundMatchs.Count < 1) return;

        List<LineMatch> lineMatched = foundMatchs.Where(line => line.matchingTile.Contains(tileTouched)).ToList();

        if (lineMatched.Count > 0)
        {
            if (lineMatched[0].isRecipe)
            {
                onRecipeMatch?.Invoke(lineMatched[0].recipe.power);
            }

            onMatch?.Invoke(lineMatched[0]);
        }
    }

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
                if (newMatch == null)
                {
                    for (int i = 0; i < player.recipes.Count; i++)
                    {
                        newMatch = CheckRecipeLineFrom(true, grid.GetTile(x, y), Vector2Int.up, player.recipes[i]);
                        if (newMatch != null) break;
                    }
                }
                if (newMatch == null) 
                { continue; }

                y += newMatch.Lenght - 1;
                foundMatchs.Add(newMatch);
            }
        }
        //Toute les lignes
        for (int y = 0; y < grid.size.y; y++)
        {
            for (int x = 0; x < grid.size.x; x++)
            {
                newMatch = CheckItemLineFrom(false, grid.GetTile(x, y), Vector2Int.right);
                if (newMatch == null)
                {
                    for (int i = 0; i < player.recipes.Count; i++)
                    {
                        newMatch = CheckRecipeLineFrom(false, grid.GetTile(x, y), Vector2Int.right, player.recipes[i]);
                        if (newMatch != null) break;
                    }
                }
                if (newMatch == null) { continue; }

                x += newMatch.Lenght - 1;
                foundMatchs.Add(newMatch);
            }
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
            newMatch = new LineMatch(vert,vert?testedTile.gridPos.x:testedTile.gridPos.y, visuPrefab, transform);
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
    public LineMatch CheckRecipeLineFrom(bool vert, GameTile testedTile, Vector2Int dir, RecipeSCO recipe)
    {
        //TODO : Le faire plus proprement
        FoodSCO food = testedTile.item.Food;
        LineMatch newMatch = null;

        if (testedTile.item.Food == recipe.ingredients[0]) 
        {
            for (int i = 0; i < recipe.ingredients.Length; i++)
            {
                food = grid.GetFood(testedTile.gridPos + dir * i);
                if (recipe.ingredients[i] != food)
                {
                    return null;
                }
            }
            //Match3 Confirmed
            newMatch = new LineMatch(vert, vert ? testedTile.gridPos.x : testedTile.gridPos.y, visuPrefab, transform, recipe);
            for (int i = 0; i < recipe.ingredients.Length; i++)
            {
                newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * i));
            }
            newMatch.UpdateLine();
        }
        else 
        if(testedTile.item.Food == recipe.ingredients.Last())
        {
            for (int i = 0; i < recipe.ingredients.Length; i++)
            {
                if (recipe.ingredients.FromEnd(i) != grid.GetFood(testedTile.gridPos + dir * i))
                {
                    return null;
                }
            }
            //Match3 Confirmed
            newMatch = new LineMatch(vert, vert ? testedTile.gridPos.x : testedTile.gridPos.y, visuPrefab, transform, recipe);
            for (int i = 0; i < recipe.ingredients.Length; i++)
            {
                newMatch.matchingTile.Add(grid.GetTile(testedTile.gridPos + dir * i));
            }
            newMatch.UpdateLine();
        }
        return newMatch;
    }

}
