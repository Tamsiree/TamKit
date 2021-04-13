/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年12月20日 20:27:35
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TamBackButton : MonoBehaviour
{
    [SerializeField]
    private KeyCode BackKey = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        Button btnBack = GetComponent<Button>();
        GUIKit.InitButtonOnClick(btnBack, () =>
        {
            BackMain();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(BackKey))
        {
            BackMain();
        }
    }

    private void BackMain()
    {
        LevelManager.Instance().LoadFirstLevel();
    }
}
