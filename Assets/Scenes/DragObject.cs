using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    
    CustomPriorityQue<ISelectAble> selectQue;

    public void Awake()
    {
        selectQue = new CustomPriorityQue<ISelectAble> ( (unitOne, unitTwo) => (unitOne.SelectPriority > unitTwo.SelectPriority));
    }

    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collObj = collision.gameObject;
        
        if(collObj.TryGetComponent<ISelectAble>(out ISelectAble selectObj))
        {
            if (!selectQue.Empty())
            {
                if (selectQue.Peek().DepthPriority > selectObj.DepthPriority)
                    selectQue.Clear();
            
            }
            selectQue.Enque(selectObj);
        }


    }

    private void OnDisable()
    {
        GameManager.instance.selectQue = selectQue;
    }


}
