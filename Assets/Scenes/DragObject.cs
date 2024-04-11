using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class DragObject : MonoBehaviour
{
    
    CustomPriorityQue<ISelectAble> selectQue;
    
    [SerializeField]
    MouseController mouseController;

    Vector3 startPos;

    float dragObj_Pos_Y = 1f;
    const float OBJ_SCALE_Y = 10f;

    Vector3 CurrentMousePos => mouseController.CurrentMousePos;


    public void Awake()
    {
        selectQue = new CustomPriorityQue<ISelectAble> ( (unitOne, unitTwo) => (unitOne.SelectPriority > unitTwo.SelectPriority));


        if (mouseController == null)
            Debug.Log("mouseController Missing");
        else
        {
            mouseController.mouseClickDown += SetStartPos;
            mouseController.mouseClick += DragObj;
            mouseController.mouseClickUp += HideDragObj;
        }
    }

    public void Start()
    {

        gameObject.SetActive(false);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject collObj = collision.gameObject;

    //    Debug.Log("collision");
    //    if(collObj.TryGetComponent<ISelectAble>(out ISelectAble selectObj))
    //    {

    //        Debug.Log("collision");
    //        if (!selectQue.Empty())
    //        {
    //            if (selectQue.Peek().DepthPriority > selectObj.DepthPriority)
    //                selectQue.Clear();
    //        }
    //        selectQue.Enque(selectObj);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        GameObject collisionObj = other.gameObject;

        if(collisionObj.TryGetComponent<ISelectAble>(out ISelectAble selectObj))
        {
            
            selectQue.Enque(selectObj);
            selectObj.IsSelected = true;
            Debug.Log("enque");
        }
    }

    private void OnDisable()
    {
        GameManager.instance.selectQue = selectQue;
        Debug.Log("selectQue size = " + selectQue.Size);
    }



    public void DragObj() 
    {

        float distanceX = (CurrentMousePos.x - startPos.x);
        float distanceZ = (CurrentMousePos.z - startPos.z);
        ResizeObj(distanceX , 1f, distanceZ);
        
    }

    public void SetStartPos()
    {
        gameObject.SetActive(true);
        startPos = CurrentMousePos;
        gameObject.transform.position = CurrentMousePos;
    }


    public void HideDragObj()
    {
        gameObject.SetActive(false);
        ResizeObj(Vector3.zero);
        selectQue.Clear();
    }

    public void ResizeObj(Vector3 size)
    {
        gameObject.transform.localScale = size;
    }
    public void ResizeObj( float x, float y, float z)
    {
        gameObject.transform.localScale = new Vector3(x, OBJ_SCALE_Y, z);

        float movePosX = (CurrentMousePos.x - startPos.x) * 0.5f;
        float movePosZ = (CurrentMousePos.z - startPos.z) * 0.5f;

        gameObject.transform.position = new Vector3(startPos.x + movePosX 
                                                  , gameObject.transform.position.y 
                                                  , startPos.z + movePosZ);


    }



}
