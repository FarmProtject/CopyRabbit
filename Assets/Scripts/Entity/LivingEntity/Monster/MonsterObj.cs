using UnityEngine;

[CreateAssetMenu(fileName = "MonsterObj", menuName = "Scriptable Objects/MonsterObj")]
public class MonsterObj : ScriptableObject
{
    MonsterEntity myEntity;


    MonsterEntity GetMonsterEntity()
    {
        return myEntity;
    }
}
