/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年05月08日 21:28:26
* |     主要功能：
* |     详细描述：
* |     版本：1.0
* ========================================================*/

using System.IO;

public class TamScriptInit : UnityEditor.AssetModificationProcessor
{
    /// <summary>
    /// 创建脚本时调用
    /// </summary>
    /// <param name="path">自动生成的脚本路径</param>
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (!path.EndsWith(".cs")) return;
        string originalFile = File.ReadAllText(path);
        if (originalFile.Contains("作者：Tamsiree"))
        {
            return;
        }
        string CommentContent = "/* ========================================================\r\n"
                               + "* |     作者：Tamsiree \r\n"
                               + "* |     创建时间：#CreateTime#\r\n"
                               + "* |     主要功能：\r\n"
                               + "* |     详细描述：\r\n"
                               + "* |     版本：1.0\r\n"
                               + "*  ======================================================== "
                               + "*/\r\n\r\n";
        CommentContent += originalFile;
        CommentContent = CommentContent.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"));
        File.WriteAllText(path, CommentContent);
    }


}
