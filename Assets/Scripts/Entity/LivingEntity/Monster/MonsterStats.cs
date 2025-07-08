using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterStats : EntityStats
{
    public Defines.MonsterType monsterType;
    public bool canStun;
    public int sturnValue;

    public MonsterStats()
    {

    }
    public MonsterStats(MonsterStats other)
    {
        this.id = other.id;
        this.name = other.name;
        this.attack = other.attack;
        this.defense = other.defense;
        this.healthPoint = other.healthPoint;
        this.moveSpeed = other.moveSpeed;
        this.attackSpeed = other.attackSpeed;
        this.attackRange = other.attackRange;
        this.aggroRange = other.aggroRange;
    }
}
