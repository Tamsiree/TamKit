/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年11月23日 16:57:47
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerminalMessage : MonoBehaviour
{
    private TextMeshProUGUI MessageTMP;

    private void Awake()
    {
        MessageTMP = GetComponent<TextMeshProUGUI>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMessage(string message)
    {
        MessageTMP.text = message;
    }
}
