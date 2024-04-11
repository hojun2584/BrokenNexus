using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseController : MonoBehaviour
{

    public bool IsMouseDrag => Input.GetMouseButton(0);
    float dragObj_Pos_Y = 1f;

    DragObject dragObjet;

    Vector3 startPos, nowPos;

    public event Action mouseClickDown;
    public event Action mouseClickUp;
    public event Action mouseClick;
    public event Action mouseClickRight;

    public Vector3 CurrentMousePos
    {
        get
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z)); ;
            pos.y = dragObj_Pos_Y;

            return pos;
        }
    }


    private void Awake()
    {
        // 커서 화면 가두는 코드 개발 테스트를 위해 주석 처리 중

        //Cursor.lockState = CursorLockMode.Confined;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (IsMouseDrag)
        //{
        //    startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        //}

        if (Input.GetMouseButtonDown(0))
        {
            mouseClickDown();
        }
        else if (Input.GetMouseButton(0))
        {
            mouseClick();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseClickUp();
        }

        if(Input.GetMouseButtonDown(1))
        {
            mouseClickRight();
        }


    }





}
