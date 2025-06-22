using UnityEngine;
using System;
using System.Collections.Generic;

public class UpgradeData
{
    public double attackUpCount;
    public double defUpCount;
    public double moveSpeedCount;
    public double healthPointCount;
}
public class UpgradeManager 
{
    UpgradeData upData = new UpgradeData();


    public void UpGreadEvent(Defines.StatType type, double Count)
    {
        for(int i = 0; i < Count; i++)
        {
            switch (type)
            {
                case Defines.StatType.Attack:
                    Up_Attack();
                    break;
                case Defines.StatType.Defence:
                    Up_Def();
                    break;
                case Defines.StatType.HealthPoint:
                    Up_HealthPoint();
                    break;
                default:
                    break;
            }
        }
    }

    public double GetUpData(Defines.StatType type)
    {
        switch (type)
        {
            case Defines.StatType.Attack:
                return GetAtkCount();

            case Defines.StatType.Defence:
                return GetDefCount();

            case Defines.StatType.HealthPoint:
                return GetHealthCount();

            default:
                return 0;

        }
    }

    public double GetAtkCount()
    {
        return upData.attackUpCount;
    }
    public double GetDefCount()
    {
        return upData.defUpCount;
    }
    public double GetHealthCount()
    {
        return upData.healthPointCount;
    }
    public double GetMoveSpeedCount()
    {
        return upData.moveSpeedCount;
    }
    void Up_Attack()
    {
        upData.attackUpCount +=1;
    }
    void Up_Def()
    {
        upData.defUpCount++;
    }
    void Up_HealthPoint()
    {
        upData.healthPointCount++;
    }
    void Up_MoveSpeed()
    {
        upData.moveSpeedCount++;
    }


}
