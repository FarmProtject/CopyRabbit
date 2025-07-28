using UnityEngine;
using System;
using System.Collections.Generic;
public static class Defines 
{
    public enum RightPanelType
    {
        Stage,
        Challenge
    }


    public enum UI_PrefabType
    {
        CellIcon,
        RewardPanel,
        CellStageButton
    }
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
    public enum MonsterType
    {
        monster,
        boss
    }
    public enum Language
    {
        kr,
        en
    }
}
