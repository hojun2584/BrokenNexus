using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterMove : IMoveStrategy
{
    protected NavMeshAgent agent;
    protected  { get; set; }


    public void Move()
    {
        throw new System.NotImplementedException();
    }
}
