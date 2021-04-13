/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月06日 20:35:45
* |     主要功能：游戏物体管理者
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using TamKit;
using UnityEngine;

public class PrefabManager : TamSingleton<PrefabManager>
{
    //游戏物体 字典
    private Dictionary<string, GameObject> gameObjectDict = new Dictionary<string, GameObject>();

    public static GameObject LoadGameObject(string gameObjectPath, bool cache = false)
    {
        if (!Instance().gameObjectDict.TryGetValue(gameObjectPath, out GameObject gameObject))
        {
            gameObject = Resources.Load<GameObject>(gameObjectPath);
            if (cache)
            {
                Instance().gameObjectDict.Add(gameObjectPath, gameObject);
            }
        }
        return gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //例子
    public static void GenerateWoodChest(Vector3 position)
    {
        GameObject gameObject = Resources.Load<GameObject>("Model/ModelWoodChest");
        GameObject.Instantiate(gameObject, position + Vector3.up, Quaternion.identity);
    }

    /**
     * 在指定的 Transform 上实例化 prefab
     */
    public static GameObject InstantiateForTransform(GameObject prefab, Transform rootTransform, Vector3 offset = default, bool isAuotParent = false, bool isAutoRotation = false)
    {
        if (prefab != null)
        {
            Quaternion quaternion;
            if (isAutoRotation)
            {
                quaternion = rootTransform.rotation;
            }
            else
            {
                quaternion = Quaternion.identity;
            }
            if (isAuotParent)
            {
                return Object.Instantiate(prefab, rootTransform.position + offset, quaternion, rootTransform);
            }
            else
            {
                return Object.Instantiate(prefab, rootTransform.position + offset, quaternion);
            }

        }
        else
        {
            Debug.LogWarning(TamTool.getClassName(2) + "的 prefab 参数 未指定");
            return null;
        }
    }

}
