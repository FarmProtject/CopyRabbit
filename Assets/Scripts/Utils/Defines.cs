using UnityEngine;
using System;
using System.Collections.Generic;
public static class Defines 
{
    #region skill
    public enum Skill_Grade
    {
        None,
        Common,
        Rare,
        Unique,
        Epic,
        Legendary
    }
    public enum TargetType
    {
        Enemy,
        Friendly,
        Self
    }
    public enum EffectType
    {
        Damage,
        Heal,
        Projectile,
        Hitbox,
        Buff
    }
    public enum ColliderShapeType
    {

    }
    public enum HitboxActiveType
    {
        Start,
        Tick,
        End
    }
    public enum BuffType
    {

    }
    public enum OverlapType
    {

    }
    public enum BuffActiveType
    {

    }
    #endregion
    #region Ui
    public enum UI_PrefabType
    {
        Cell_Icon,
        RewardPanel,
        Cell_StageRight,
        MenuButton,
        Cell_StageLeft
    }
    public enum MenuType
    {
        Menu,
        Combat,
        Shop
    }
    public enum MenuSubPanels
    {
        Options
    }
    public enum DungeonType
    {
        Portal,
        Gem,
        Skill,
        Gold,
        Tower,
        Boss
    }
    public enum ShopSubPanels
    {
        Skill,
        Weapon
    }

    public enum UIEvents
    {
        Click,
        DragStart,
        Drag,
        DragEnd
    }
    #endregion
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
