/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月06日 20:41:25
* |     主要功能：音频管理者
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : TamSingletonMono<GameManager>
{
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    private Dictionary<string, AudioSource> audioSourceDict = new Dictionary<string, AudioSource>();

    public AudioClip LoadAudioClip(string audioClipPath, bool cache = false)
    {
        AudioClip audioClip = null;
        if (!audioClipDict.TryGetValue(audioClipPath, out audioClip))
        {
            audioClip = Resources.Load<AudioClip>(audioClipPath);
            if (cache)
            {
                audioClipDict.Add(audioClipPath, audioClip);
            }
        }
        return audioClip;
    }

    public void AudioPlayAtCamera(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }

    public static bool isMute = false;

    public void SetMute(bool isMute)
    {
        AudioManager.isMute = isMute;
        var e = audioSourceDict.GetEnumerator();
        while (e.MoveNext())
        {
            e.Current.Value.Pause();
        }
    }

    /*
     //测试 
     public static void SwordNormalAttack()
     {
         AudioClip audioClip = AudioManager.Instance.LoadAudioClip("Sound/sword_swipe", true);
         Instance.weaponAttackSound.clip = audioClip;
         Instance.weaponAttackSound.volume = 1f;
         Instance.weaponAttackSound.Play();
     }

     //----------------------------------------以下为敌人声音-----------------------------------------------

     public static void WolfNormalAttack(AudioSource audioSource)
     {
         AudioClip audioClip = AudioManager.Instance.LoadAudioClip("Sound/Sword Swing", true);
         audioSource.clip = audioClip;
         audioSource.Play();
     }*/
}
