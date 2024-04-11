using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitInfo
{
    public string name;
    public float moveSpeed;
    public int maxHp;
    public int hp;
    public int armor;
    public int attackSpeed;
    public int attackPoint;
    public int mana;
}



public interface IUnitAble
{
    void Move();
    void Attack();
    void Die();
}

public interface IMoveStrategy
{
    void Move();
}
public interface IAttackStrategy 
{
    void Attack();  
}

public interface IDieStartegy
{
    void Die();
}

public interface AbstractFactory
{
    IMoveStrategy MakeMoveStrategy();
    IAttackStrategy MakeAttackstartegy();
}

public class Fatory : AbstractFactory
{
    public IAttackStrategy MakeAttackstartegy()
    {
        throw new System.NotImplementedException();
    }

    public IMoveStrategy MakeMoveStrategy()
    {
        throw new System.NotImplementedException();
    }
}