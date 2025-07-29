using UnityEngine;
using System;
using System.Collections.Generic;
public static class Defines 
{
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

    public enum StageClearType
    {
        Normal,
        Boss,
        Object
    }
    
    public enum StageType
    {
        Stage,
        Challenge
    }

    public enum MonsterActState
    {
        Move,
        Attack,
        Stay
    }
    public enum MonsterType
    {
        Monster,
        Boss
    }
    public enum Language
    {
        Kr,
        En
    }
}
