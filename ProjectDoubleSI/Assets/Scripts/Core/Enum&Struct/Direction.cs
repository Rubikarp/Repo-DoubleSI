using System;
using UnityEngine;

public enum DirectionEnum
{
    error = -1,
    down = 0,
    right = 1,
    up = 2,
    left = 3,
}

[Serializable]
public struct Direction
{
    [Header("Variable")]
    public Vector2Int dirValue;
    public DirectionEnum dirEnum;
    public int x { set { dirValue.x = value; } }
    public int y { set { dirValue.y = value; } }

    #region Constructor
    public Direction(int _x, int _y)
    {
        this.dirValue = new Vector2Int(_x, _y);
        this.dirEnum = DirectionEnum.down;

        DirectionEnum temp = Vec2ToDirEnum(dirValue);
        this.dirEnum = temp;
    }
    public Direction(Vector2Int _value)
    {
        this.dirValue = _value;
        this.dirEnum = DirectionEnum.down;

        DirectionEnum temp = Vec2ToDirEnum(dirValue);
        this.dirEnum = temp;
    }
    public Direction(DirectionEnum _dirEnum)
    {
        this.dirValue = Vector2Int.zero;
        this.dirEnum = _dirEnum;

        Vector2Int temp = DirEnumToVec2(_dirEnum);
        this.dirValue = temp;
    }
    public Direction(int _intDir)
    {
        this.dirValue = Vector2Int.zero;
        this.dirEnum = (DirectionEnum)_intDir;

        Vector2Int temp = DirEnumToVec2((DirectionEnum)_intDir);
        this.dirValue = temp;
    }
    public Direction(Vector2Int _value, DirectionEnum _dirEnum)
    {
        this.dirValue = _value;
        this.dirEnum = _dirEnum;
    }
    #endregion

    #region StaticVariable
    public static Direction down = new Direction(new Vector2Int(0, -1), DirectionEnum.down);
    public static Direction right = new Direction(new Vector2Int(1, 0), DirectionEnum.right);
    public static Direction up = new Direction(new Vector2Int(0, 1), DirectionEnum.up);
    public static Direction left = new Direction(new Vector2Int(-1, 0), DirectionEnum.left);
    #endregion

    //Conversion
    public static DirectionEnum Vec2ToDirEnum(Vector2Int dir)
    {
        dir.x = Mathf.Clamp(dir.x, -1, 1);
        dir.y = Mathf.Clamp(dir.y, -1, 1);

        #region HandSwitch

        if (dir == up.dirValue)
        {
            return up.dirEnum;
        }
        else
        if (dir == right.dirValue)
        {
            return right.dirEnum;
        }
        else
        if (dir == down.dirValue)
        {
            return down.dirEnum;
        }
        else
        if (dir == left.dirValue)
        {
            return left.dirEnum;
        }
        #endregion

        return down.dirEnum;
    }
    public static Vector2Int DirEnumToVec2(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.up:
                return up.dirValue;

            case DirectionEnum.right:
                return right.dirValue;

            case DirectionEnum.down:
                return down.dirValue;

            case DirectionEnum.left:
                return left.dirValue;

            default:
                return down.dirValue;
        }
    }
    public static Direction DirFromInt(int _dirIndex)
    {
        return new Direction(_dirIndex);
    }

    //Methode
    public static bool IsVertical(Direction dir)
    {
        return ((int)dir.dirEnum % 2) == 0;
    }
    public static Direction Inverse(Direction dir)
    {
        return new Direction(dir.dirValue * (-Vector2Int.one));
    }
    public static Vector2Int ClampDir(Vector2Int dir)
    {
        dir.x = Mathf.Clamp(dir.x, -1, 1);
        dir.y = Mathf.Clamp(dir.y, -1, 1);

        return dir;
    }
}
