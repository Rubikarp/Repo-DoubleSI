using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable] 
public class TileEvent : UnityEvent<GameTile> { }
[System.Serializable]
public class SwapEvent : UnityEvent<GameTile, GameTile> { }

public class GameGridInteraction : MonoBehaviour
{
    public InputHandler input;
    public GameGrid grid;
    public GameGridManager gridManager;

    [Header("Switch")]
    [SerializeField] public GameTile startSelectTile;
    [Space(10)]
    [SerializeField] private GameTile endSelectTile;
    [Space(10)]
    [SerializeField] public Vector3 dragPos;
    [SerializeField] public Vector3 dragVect;

    void OnEnable()
    {
        input.onInputPress.AddListener(InputPress);
        input.onInputMaintain.AddListener(InputMaintain);
        input.onInputRelease.AddListener(InputRelease);
    }

    private void OnDisable()
    {
        input.onInputPress.RemoveListener(InputPress);
        input.onInputMaintain.RemoveListener(InputMaintain);
        input.onInputRelease.RemoveListener(InputRelease);
    }

    //InputMode
    private void InputPress()
    {
        //Initialise start select
        startSelectTile = grid.GetTile(grid.PosToTile(input.GetHitPos()));
    }
    private void InputMaintain()
    {
        dragPos = input.GetHitPos();
        dragVect = (dragPos - startSelectTile.worldPos);

        if (dragVect.magnitude > (grid.cellSize/2))
        {
            SwitchTry();

            input.isMaintaining = false;
        }
    }
    private void InputRelease()
    {
        SwitchTry();

        if (startSelectTile == endSelectTile)
        {
            //Combo validate
        }

            //Reset
            startSelectTile = null;
        //
        endSelectTile = null;
        //
        dragPos = Vector3.zero;
        dragVect = Vector3.zero;
    }

    public void SwitchTry()
    {
        //Dans la zone
        if (grid.InZone(input.hitPoint))
        {
            endSelectTile = grid.GetTile(grid.PosToTile(input.GetHitPos()));

            if (startSelectTile != endSelectTile)
            {
                Vector2Int tileToMe = endSelectTile.gridPos - startSelectTile.gridPos;
                tileToMe.x = Mathf.Clamp(tileToMe.x, -1, 1);
                tileToMe.y = Mathf.Clamp(tileToMe.y, -1, 1);

                if(Mathf.Abs(tileToMe.magnitude-1) < 0.05f)
                {
                    gridManager.Switch(startSelectTile, endSelectTile);
                }
            }
        }
    }
}
