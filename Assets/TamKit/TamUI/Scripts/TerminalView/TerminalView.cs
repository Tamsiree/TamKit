/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 16:52:37
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class TerminalView : MonoBehaviour
{
    private string TerminalMessagePrefab = "Assets/TamKit/Assets/Prefab/TerminalMessage.prefab";

    private Scrollbar scrollbar = null;

    private Transform messageContent = null;

    // Start is called before the first frame update
    void Start()
    {
        messageContent = transform.Find("TerminalScrollView/Viewport/Content");
        scrollbar = transform.Find("TerminalScrollView/Scrollbar Vertical").GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddMessage(string message)
    {
        //Addressables.InstantiateAsync("AssetAddress").Completed += OnLoadDone;
        /*  Addressables.InstantiateAsync(TerminalMessagePrefab).Completed += delegate (AsyncOperationHandle<GameObject> obj)
          {
              GameObject gameObject = PrefabManager.InstantiateForTransform(obj.Result, messageContent, default, true);
              gameObject.GetComponent<TerminalMessage>().SetMessage(message);
              OnScrollBottom();
          };*/

        AddressableKit.InstantiateAsync(TerminalMessagePrefab, (AsyncOperationHandle<GameObject> obj) =>
        {
            GameObject gameObject = PrefabManager.InstantiateForTransform(obj.Result, messageContent, default, true);
            gameObject.GetComponent<TerminalMessage>().SetMessage(message);
            OnScrollBottom();
        });
    }


    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        // In a production environment, you should add exception handling to catch scenarios such as a null result.

    }

    private void OnScrollBottom()
    {
        StartCoroutine("InsSrollBar");
    }

    IEnumerator InsSrollBar()
    {
        yield return new WaitForEndOfFrame();
        scrollbar.value = 0;
    }
}
