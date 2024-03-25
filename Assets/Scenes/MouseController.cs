using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public bool IsMouseDrag => Input.GetMouseButtonDown(0);
    GameObject dragObjet;

    Vector3 startPos, nowPos;

    


    // Update is called once per frame
    void Update()
    {

        if (IsMouseDrag)
        {
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
            
        }

    }



}
