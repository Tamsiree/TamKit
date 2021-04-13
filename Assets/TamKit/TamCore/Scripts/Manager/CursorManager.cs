/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月06日 20:40:21
* |     主要功能：
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : TamSingletonMono<GameManager>
{
    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;

    private Vector2 hotspot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal, hotspot, cursorMode);
    }

    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npc_talk, hotspot, cursorMode);
    }

    public void SetAttack()
    {
        Cursor.SetCursor(cursor_attack, hotspot, cursorMode);
    }

    public void SetLockTarget()
    {
        Cursor.SetCursor(cursor_lockTarget, hotspot, cursorMode);
    }

    public void SetPick()
    {
        Cursor.SetCursor(cursor_pick, hotspot, cursorMode);
    }
}
