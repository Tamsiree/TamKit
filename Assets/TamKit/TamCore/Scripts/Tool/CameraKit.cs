/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月14日 20:08:03
* |     主要功能：Camera工具
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKit
{

    public static void RotateAround(Transform cameraTransform, Vector3 vector3, float rotateSpeed = 20)
    {
        cameraTransform.RotateAround(vector3, Vector3.up, Time.deltaTime * rotateSpeed);
    }

}
