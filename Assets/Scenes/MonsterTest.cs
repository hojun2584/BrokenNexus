using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTest : MonoBehaviour ,ISelectAble
{

    bool isSelected;

    public bool IsSelected { 
        get => isSelected; 
        set{
            if(value == true)
            {
                mouseController.mouseClickRight += SetAgentDestination;
            }
            else
            {
                mouseController.mouseClickRight -= SetAgentDestination;
            }
            isSelected = value;
        }
    }

    public int SelectPriority => 1;

    public int DepthPriority => 1;

    public MouseController mouseController;
    NavMeshAgent agent;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (mouseController == null)
        {
            Debug.Log("mouseController is missing");
        }
        else
        {
            mouseController.mouseClickRight += SetAgentDestination;
        }

    }

    private void SetAgentDestination()
    {
        agent.SetDestination(mouseController.CurrentMousePos);
    }


}
