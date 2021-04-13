/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 20:10:12
* |     主要功能：将此脚本挂载到某物体下，则会控制主相机 以 此物体 为中心 自动 逆时针旋转
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamAutoRotate : MonoBehaviour
{
    private bool isAutoRotate = true;

    [SerializeField]
    float autoRotateSpeed = 10;

    [SerializeField]
    [Tooltip("缩放大小的速度")]
    float scaleSpeed = 1000f;

    [SerializeField]
    float scaleMax = 10;

    [SerializeField]
    float scaleMin = 3;

    [SerializeField]
    [Tooltip("水平旋转的速度")]
    float rotateSpeed = 100;

    [SerializeField]
    [Tooltip("垂直旋转的速度")]
    float xRotateSpeed = 3;

    [SerializeField]
    [Tooltip("是否开启鼠标旋转")]
    private bool isMouseRotate;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectTemp = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        InitView();
    }

    GameObject gameObjectTemp;

    void InitView()
    {
        if (isMouseRotate)
        {
            if (Input.GetMouseButton(0))
            {
                isAutoRotate = false;

                float _mouseX = Input.GetAxis("Mouse X");
                float _mouseY = Input.GetAxis("Mouse Y");
                CameraRotate(_mouseX, _mouseY);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isAutoRotate = true;
            }
        }

        //放大、缩小
        float scaleValue = Input.GetAxis("Mouse ScrollWheel");
        if (scaleValue != 0)
        {
            float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
            //Debug.Log("Distance:" + distance);
            if (distance > scaleMax && scaleValue < 0)
            {
                return;
            }

            if (distance < scaleMin && scaleValue > 0)
            {
                return;
            }

            Camera.main.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scaleSpeed);
        }

        if (isAutoRotate)
        {
            CameraKit.RotateAround(Camera.main.transform, transform.position, autoRotateSpeed);
        }
    }

    /// <summary>
    /// 左键控制旋转
    /// </summary>
    /// <param name="_mouseX"></param>
    /// <param name="_mouseY"></param>
    public void CameraRotate(float _mouseX, float _mouseY)
    {
        //控制相机绕中心点(centerPoint)水平旋转
        Camera.main.transform.RotateAround(transform.position, Vector3.up, _mouseX * rotateSpeed * Time.deltaTime);

        Vector3 vector3 = Camera.main.transform.eulerAngles;
        //Debug.LogFormat("x:{0},y:{1}", vector3.x, vector3.y);
        if (vector3.x > 70 && _mouseY < 0)
        {
            return;
        }


        if (vector3.x < 10 && _mouseY > 0)
        {
            return;
        }

        gameObjectTemp.transform.position = Camera.main.transform.position;
        gameObjectTemp.transform.eulerAngles = Camera.main.transform.eulerAngles;

        gameObjectTemp.transform.RotateAround(transform.position, gameObjectTemp.transform.right, -_mouseY * xRotateSpeed);

        if (gameObjectTemp.transform.eulerAngles.x < 10 || gameObjectTemp.transform.eulerAngles.x > 70)
        {
            return;
        }

       

        if (Mathf.Abs(_mouseY) > 5)
        {
            if (_mouseY > 0)
            {
                _mouseY = 5;
            }
            else
            {
                _mouseY = -5;
            }
        }

        //Debug.Log("_mouseY:" + _mouseY);

        //17.12
        //控制相机绕中心点垂直旋转(！注意此处的旋转轴时相机自身的x轴正方向！)
        Camera.main.transform.RotateAround(transform.position, Camera.main.transform.right, -_mouseY * xRotateSpeed);

    }
}
