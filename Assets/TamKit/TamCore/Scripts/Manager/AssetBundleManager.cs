/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年07月18日 16:53:00
* |     主要功能：AssetBundle管理者
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleManager : MonoBehaviour
{
    public static GameObject LoadAssetBundleFromFile(string assetBundlePath, string name)
    {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
        GameObject prefab = assetBundle.LoadAsset<GameObject>(name);
        return prefab;
    }

    public static Object[] LoadAssetBundlesFromFile(string assetBundlePath)
    {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
        Object[] objects = assetBundle.LoadAllAssets();
        return objects;
    }

    public static IEnumerator LoadAssetBundleFromURI(string uri, string name)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        yield return request.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        GameObject sp = ab.LoadAsset<GameObject>(name);
    }



    public static AssetBundleManifest LoadAssetBundleManifest(string targetPlatform)
    {
        string path = "AssetBundles/" + targetPlatform.ToString() + "/" + targetPlatform.ToString();
        Debug.Log("Path: " + path);
        AssetBundle manifest = AssetBundle.LoadFromFile(path);
        AssetBundleManifest bundleManifest = manifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        return bundleManifest;
    }

    public static void LoadAssetBundlesDependencies(AssetBundleManifest manifest, string targetPlatform, string fileName)
    {
        string[] strs = manifest.GetAllDependencies(fileName);
        Debug.Log("strs.size = " + strs.Length);
        foreach (string item in strs)
        {
            Debug.Log("item:" + item);
            AssetBundle.LoadFromFile("AssetBundles/" + targetPlatform + "/" + item);
        }
    }
}
