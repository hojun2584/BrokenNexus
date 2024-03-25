using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitAble
{
    void Move();
    void Attack();
    void Die();
}

public interface MoveStrategy
{
    void Move();
}
public interface AttackStrategy 
{
    void Attack();  
}

public interface DieStartegy
{
    void Die();
}

public interface AbstractFactory
{
    MoveStrategy MakeMoveStrategy();
    AttackStrategy MakeAttackstartegy();
}

public class Fatory : AbstractFactory
{
    public AttackStrategy MakeAttackstartegy()
    {
        throw new System.NotImplementedException();
    }

    public MoveStrategy MakeMoveStrategy()
    {
        throw new System.NotImplementedException();
    }
}