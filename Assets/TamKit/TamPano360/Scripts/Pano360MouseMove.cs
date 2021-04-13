/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 13:38:48
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pano360MouseMove : MonoBehaviour
{

    private bool isAutoRotate = true;

    //[SerializeField]
    float autoRotateSpeed = 5;

    public float sensitivityMouse = 2f;
    public float sensitivetyKeyBoard = 0.1f;
    public float sensitivetyMouseWheel = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //滚轮实现镜头缩进和拉远
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView = Camera.main.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * sensitivetyMouseWheel;
        }
        //按着鼠标右键实现视角转动
        if (Input.GetMouseButton(0))
        {
            if (transform != null)
            {
                transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivityMouse, Input.GetAxis("Mouse X") * sensitivityMouse, 0);
            }
            isAutoRotate = false;
        }


        if (transform.localEulerAngles.z != 0)
        {
            if (transform != null)
            {
                float rotX = transform.localEulerAngles.x;
                float rotY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(rotX, rotY, 0);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isAutoRotate = true;
        }

        if (isAutoRotate)
        {
            //CameraKit.RotateAround(Camera.main.transform, transform.position, autoRotateSpeed);

            if (transform != null)
            {
                transform.Rotate(Vector3.up, Time.deltaTime * autoRotateSpeed);
            }
        }
    }
}

