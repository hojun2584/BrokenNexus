using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public float camSpeed = 20f;
    public bool isCameraMove = true;
    public Camera mainCamera;
    public float windowBording = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        if(mainCamera == null)
        {
            Debug.Log("mainCamera is missing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }


    void CameraMove()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float cameraZ = 1.0f;
        float cameraY = 1.0f;


        if (Screen.height <= Input.mousePosition.y + windowBording)
        {
            cameraPosition.z += camSpeed * Time.deltaTime;
        }
        else if ( 1 >= Input.mousePosition.y - windowBording)
        {
            cameraPosition.z -= camSpeed * Time.deltaTime;
        }

        if (Screen.width <= Input.mousePosition.x + windowBording)
        {
            cameraPosition.x += camSpeed * Time.deltaTime;
        }
        else if ( 1 >= Input.mousePosition.x - windowBording)
        {
            cameraPosition.x -= camSpeed * Time.deltaTime;
        }


        mainCamera.transform.position = cameraPosition;

    }

}
