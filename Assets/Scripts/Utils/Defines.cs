using UnityEngine;
using System;
using System.Collections.Generic;
public static class Defines 
{
    public enum UIEvents
    {
        Click,
        DragStart,
        Drag,
        DragEnd
    }
    public enum LeverType 
    {
        Fixed,
        Floating
    }
    public enum PlayerControllType
    {
        Auto,
        Manual
    }
    public enum StatType
    {
        Attack,
        Defence,
        HealthPoint
    }
    public enum StageType
    {
        Infinity,
        KillCount,
        Boss
    }
    public enum MonsterActState
    {
        Move,
        Attack,
        Stay
    }
}
