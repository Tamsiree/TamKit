/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月27日 20:12:21
* |     主要功能：
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TamSingletonMono<GameManager>
{

    [SerializeField]
    private KeyCode exitKeyCode = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(exitKeyCode))
        {
            ExitGame();
        }
    }

    public void GameReplay()
    {
        LevelManager.Instance().ReloadCurrentLevel();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()//退出运行
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
