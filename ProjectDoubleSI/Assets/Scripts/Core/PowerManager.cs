using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using NaughtyAttributes;

public enum GamePowers
{
    NextRecipeScoreMult,
    ToolCooldownReset,
    NoSwitchCancel,
    TempScoreMult,
    RecipeTempScoreMult,
    LineDestroy,
    MaxManaUp,
    SquareDestroy,
    IngredientLine,
    ShuffleBoard,
    ManaThreeUp,
    NextScoreBonusDouble,
}

[System.Serializable]
public class PowerEvent : UnityEvent<GamePowers> { }

public class PowerManager : MonoBehaviour
{
    [Header("Reference")]
    public GameGrid grid;
    public ManaManager mana;
    private PlayerHand player;
    public PointCalculator points;
    public GameGridManager gridManage;
    public List<UtensilCard> cards = new List<UtensilCard>();


    public void LaunchPower(GamePowers power)
    {
        switch (power)
        {
            case GamePowers.NextRecipeScoreMult:
                NextScoreBonus();
                break;
            case GamePowers.ToolCooldownReset:
                ToolCooldownReset();
                break;
            case GamePowers.TempScoreMult:
                TempScoreBonus();
                break;
            case GamePowers.RecipeTempScoreMult:
                RecipeTempScoreBonus();
                break;
            case GamePowers.LineDestroy:
                ClearRandomLine();
                break;
            case GamePowers.SquareDestroy:
                ClearRandomSquare();
                break;
            case GamePowers.MaxManaUp:
                MaxManaUp();
                break;
            case GamePowers.IngredientLine:
                SameIngredientLine();
                break;
            case GamePowers.ShuffleBoard:
                ShuffleBoard();
                break;
            case GamePowers.ManaThreeUp:
                ManaThreeUp();
                break;
            case GamePowers.NextScoreBonusDouble:
                NextScoreBonusDouble();
                break;
            default:
                Debug.LogError("Invalid Power");
                break;
        }

    }


    /// <summary>
    /// Supprime un ligne du board aléatoirement
    /// </summary>
    [Button]
    public void ClearRandomLine()
    {
        bool vert = Random.Range(0, 2) == 0;
        List<GameTile> aimTiles = gridManage.SelectALine(vert, Random.Range(0, vert ? grid.size.x : grid.size.y));
        gridManage.ClearTiles(aimTiles);
    }

    /// <summary>
    /// Supprime un block de 3x3 block du board aléatoirement
    /// </summary>
    [Button]
    public void ClearRandomSquare()
    {
        int column = Random.Range(0, grid.size.x - 2);
        int line = Random.Range(0, grid.size.y - 2);

        List<GameTile> aimTiles = new List<GameTile>();
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                aimTiles.Add(grid.GetTile(line + y, column + x));
            }
        }
        gridManage.ClearTiles(aimTiles);
    }

    /// <summary>
    /// réduit à 0 le cooldown d'un ustensile aléatoire
    /// </summary>
    [Button]
    public void ToolCooldownReset()
    {
        //réduit à 0 le cooldown d'un ustensile aléatoire
        List<UtensilCard> cardsInCD = cards.Where(card => !card.usable).ToList();

        if (cardsInCD.Count <= 0) return;
        cardsInCD.Random().ResetCD();
    }

    /// <summary>
    /// augmente de 25% le gain de score des prochains matchs pendant 10 secondes
    /// </summary>
    [Button]
    public void TempScoreBonus()
    {
        points.FeverTime(10f, 1.25f);
    }

    /// <summary>
    /// augmente de 25% le gain de score des prochaines recettes pendant 20 secondes
    /// </summary>
    [Button]
    public void RecipeTempScoreBonus()
    {
        points.FeverTime(20f, 1.25f);
    }

    /// <summary>
    /// augmente de 50% le gain de score de la prochaine recette
    /// </summary>
    [Button]
    public void NextScoreBonus()
    {
        points.NextScoreBonus(1.5f);
    }

    /// <summary>
    /// augmente de 100% le gain de score de la prochaine recette
    /// </summary>
    [Button]
    public void NextScoreBonusDouble()
    {
        points.NextScoreBonusDouble(2f);
    }

    /// <summary>
    /// ajoute 1 de mana max permanent
    /// </summary>
    [Button]
    public void MaxManaUp()
    {
        mana.MaxManaUp(1);
    }

    /// <summary>
    /// Randomly change all item
    /// </summary>
    [Button]
    public void ShuffleBoard()
    {
        gridManage.ShuffleGrid();
    }

    public void ManaThreeUp()
    {
        mana.ManaUp(3);

        /// <summary>
        /// Randomly change all item
        /// </summary>
    }

    [Button]
    public void SameIngredientLine()
    {
        bool vert = Random.Range(0, 2) == 0;
        List<GameTile> line = gridManage.SelectALine(vert, Random.Range(0, vert ? grid.size.x : grid.size.y));
        FoodSCO ingredient = player.availableIngredients.Random();

        foreach (var tile in line)
        {
            tile.item.Food = ingredient;
        }
    }
}
