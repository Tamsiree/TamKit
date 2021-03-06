/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年10月15日 11:37:25
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOutline : PostEffectsBase
{
    public Camera additionalCamera;
    public Shader drawOccupied;

    public Color outlineColor = Color.green;
    [Range(0, 10)]
    public int outlineWidth = 4;
    [Range(0, 9)]
    public int iterations = 1;

    private RenderTexture tempRT;

    public string layerName;

    private void Awake()
    {
        SetupAddtionalCamera();
    }

    private void SetupAddtionalCamera()
    {
        additionalCamera.CopyFrom(MainCamera);
        additionalCamera.clearFlags = CameraClearFlags.Color;
        additionalCamera.backgroundColor = Color.black;
        additionalCamera.cullingMask = 1 << LayerMask.NameToLayer(layerName);       // 只渲染"Outline"层的物体
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (TargetMaterial != null && drawOccupied != null && additionalCamera != null)
        {
            tempRT = RenderTexture.GetTemporary(source.width, source.height, 0);
            additionalCamera.targetTexture = tempRT;

            // 额外相机中使用shader，绘制出物体所占面积
            additionalCamera.RenderWithShader(drawOccupied, "");

            TargetMaterial.SetTexture("_SceneTex", source);
            TargetMaterial.SetColor("_Color", outlineColor);
            TargetMaterial.SetInt("_Width", outlineWidth);
            TargetMaterial.SetInt("_Iterations", iterations);

            // 使用描边混合材质实现描边效果
            Graphics.Blit(tempRT, destination, TargetMaterial);

            tempRT.Release();
        }
        else
            Graphics.Blit(source, destination);
    }

}
