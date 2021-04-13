/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年08月17日 19:04:54
* |     主要功能：调用Window系统的文件选择窗口
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System;

using System.Collections;

using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using UnityEditor;
using UnityEngine;


[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenDialogFile
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public String filter = null;
    public String customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public String file = null;
    public int maxFile = 0;
    public String fileTitle = null;
    public int maxFileTitle = 0;
    public String initialDir = null;
    public String title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public String defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public String templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenDialogDir
{
    //对话框的所有者窗口的句柄
    public IntPtr hwndOwner = IntPtr.Zero;

    //一个PIDL，它指定要从其开始浏览的根文件夹的位置。
    //对话框中仅显示名称空间层次结构中的指定文件夹及其子文件夹。
    //该成员可以为NULL。
    //在这种情况下，将使用默认位置。
    public IntPtr pidlRoot = IntPtr.Zero;

    //存放目录路径缓冲区
    public String pszDisplayName = null;

    //标题
    public String lpszTitle = null;

    //样式
    public UInt32 ulFlags = 0;

    //指向事件发生时对话框调用的应用程序定义函数的指针。
    //有关更多信息，请参见BrowseCallbackProc函数。
    //该成员可以为NULL。
    public IntPtr lpfn = IntPtr.Zero;


    //对话框传递给回调函数的应用程序定义的值（如果在lpfn中指定了值）。
    public IntPtr lParam = IntPtr.Zero;

    //一个整数值，用于接收与所选文件夹关联的图像的索引，该索引存储在系统映像列表中。
    public int iImage = 0;

    public String initialDir = null;
}

public class WindowsExplorer
{
    //仅返回文件系统目录。
    //如果用户选择了不属于文件系统的文件夹，则“确定”按钮将显示为灰色。
    private const uint BIF_RETURNONLYFSDIRS = 0x00000001;

    //不要在对话框的树视图控件中的域级别以下包括网络文件夹。
    private const uint BIF_DONTGOBELOWDOMAIN = 0x00000002;

    //在对话框中包括一个状态区域。
    //回调函数可以通过将消息发送到对话框来设置状态文本。
    //指定BIF_NEWDIALOGSTYLE时不支持此标志。
    private const uint BIF_STATUSTEXT = 0x00000004;

    //仅返回文件系统祖先。
    //祖先是位于名称空间层次结构中根文件夹下方的子文件夹。
    //如果用户选择的根文件夹的祖先不属于文件系统，则“确定”按钮将显示为灰色。
    private const uint BIF_RETURNFSANCESTORS = 0x00000008;

    //在浏览对话框中包括一个编辑控件，该控件允许用户键入项目的名称。
    private const uint BIF_EDITBOX = 0x00000010;

    //如果用户在编辑框中输入了无效的名称，则浏览对话框将使用BFFM_VALIDATEFAILED消息调用应用程序的BrowseCallbackProc。
    //如果未指定BIF_EDITBOX，则忽略此标志。
    private const uint BIF_VALIDATE = 0x00000020;

    //使用新的用户界面。
    //设置此标志将为用户提供一个可以调整大小的较大对话框。
    //该对话框具有几个新功能，包括：对话框内的拖放功能，重新排序，快捷菜单，新文件夹，删除和其他快捷菜单命令。
    private const uint BIF_NEWDIALOGSTYLE = 0x00000040;

    // 浏览对话框可以显示URL。
    //还必须设置 BIF_USENEWUI 和 BIF_BROWSEINCLUDEFILES 标志。
    //如果未设置这三个标志中的任何一个，则浏览器对话框将拒绝URL。
    //即使设置了这些标志，仅当包含所选项目的文件夹支持URL时，浏览对话框才会显示URL。
    //当调用文件夹的 IShellFolder::GetAttributesOf 方法以请求所选项目的属性时，该文件夹必须设置 SFGAO_FOLDER 属性标志。
    //否则，浏览对话框将不会显示URL。
    private const uint BIF_BROWSEINCLUDEURLS = 0x00000080;

    //使用新的用户界面，包括一个编辑框。
    //此标志等效于 BIF_EDITBOX | BIF_NEWDIALOGSTYLE。
    private const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);

    //与 BIF_NEWDIALOGSTYLE 结合使用时，将使用提示添加到对话框中，代替编辑框。
    // BIF_EDITBOX 会覆盖此标志。
    private const uint BIF_UAHINT = 0x00000100;

    //不要在浏览对话框中包括“新建文件夹”按钮。
    private const uint BIF_NONEWFOLDERBUTTON = 0x00000200;

    //当所选项目是快捷方式时，返回快捷方式本身而不是其目标的PIDL。
    private const uint BIF_NOTRANSLATETARGETS = 0x00000400;

    //只返回计算机。
    //如果用户选择的不是计算机，则“确定”按钮将显示为灰色。
    private const uint BIF_BROWSEFORCOMPUTER = 0x00001000;

    //只允许选择打印机。
    //如果用户选择打印机以外的其他任何东西，则“确定”按钮将显示为灰色。
    //在Windows XP和更高版本的系统中，最佳实践是使用Windows XP样式的对话框，将对话框的根目录设置为Printers and Faxes文件夹（CSIDL_PRINTERS）。
    private const uint BIF_BROWSEFORPRINTER = 0x00002000;

    //浏览对话框显示文件和文件夹。
    private const uint BIF_BROWSEINCLUDEFILES = 0x00004000;

    //浏览对话框可以显示远程系统上的可共享资源。
    //这适用于希望在本地系统上公开远程共享的应用程序。
    //还必须设置BIF_NEWDIALOGSTYLE标志。
    private const uint BIF_SHAREABLE = 0x00008000;

    //Windows 7及更高版本。
    //允许浏览文件夹连接，例如库或扩展名为.zip的压缩文件。
    private const uint BIF_BROWSEFILEJUNCTIONS = 0x00010000;


    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenDialogFile ofn);

    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetSaveFileName([In, Out] OpenDialogFile ofn);

    [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SHBrowseForFolder([In, Out] OpenDialogDir ofn);

    [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool SHGetPathFromIDList([In] IntPtr pidl, [In, Out] char[] fileName);

    /// <summary>
    /// 释放命令行管理程序分配的ITEMIDLIST结构
    /// Frees an ITEMIDLIST structure allocated by the Shell.
    /// </summary>
    /// <param name="pidlList"></param>
    [DllImport("shell32.dll", ExactSpelling = true)]
    public static extern void ILFree(IntPtr pidlList);


    /// <summary>
    /// 返回与指定文件路径关联的ITEMIDLIST结构。
    /// Returns the ITEMIDLIST structure associated with a specified file path.
    /// </summary>
    /// <param name="pszPath"></param>
    /// <returns></returns>
    [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    public static extern IntPtr ILCreateFromPathW(string pszPath);



    /// <summary>
    /// 调用WindowsExploer 并返回所选文件夹路径
    /// </summary>
    /// <param name="dialogtitle">打开对话框的标题</param>
    /// <returns>所选文件夹路径</returns>
    public static string GetPathFromWindowsExplorer(string dialogtitle = "请选择下载路径")
    {
        string res;

        OpenDialogDir ofn2 = new OpenDialogDir();
        // 存放目录路径缓冲区  
        ofn2.pszDisplayName = new string(new char[2000]);

        ofn2.pidlRoot = ILCreateFromPathW(Application.dataPath.Replace('/', '\\'));

        // 标题  
        ofn2.lpszTitle = dialogtitle;

        // 新的样式,带编辑框  
        ofn2.ulFlags = BIF_NEWDIALOGSTYLE;

        IntPtr pidlPtr = WindowsExplorer.SHBrowseForFolder(ofn2);

        char[] charArray = new char[2000];
        for (int i = 0; i < 2000; i++)
            charArray[i] = '\0';

        WindowsExplorer.SHGetPathFromIDList(pidlPtr, charArray);
        res = new String(charArray);
        res = res.Substring(0, res.IndexOf('\0'));
        return res;
    }

    public static string GetFileFromWindowsExplorer()
    {
        var backPath = "";

        OpenDialogFile openFileName = new OpenDialogFile();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = Application.dataPath.Replace('/', '\\');//默认路径
        openFileName.title = "打开文件";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;
        if (WindowsExplorer.GetSaveFileName(openFileName))
        {
            Debug.Log(openFileName.file);
            Debug.Log(openFileName.fileTitle);
            backPath = openFileName.file;
        }

        return backPath;
    }



    /// <summary>
    /// 绝对路径转相对路径
    /// </summary>
    /// <param name="strUrl"></param>
    /// <returns></returns>
    public static string UrlConvertor(string path, string rootName = TamConst.Assets)
    {
        if (string.IsNullOrEmpty(path))
        {
            return "";
        }
        path = path.Substring(path.IndexOf(rootName));
        path = path.Replace('\\', '/');
        return path;
    }

    /// <summary>
    /// 相对路径转绝对路径
    /// </summary>
    /// <param name="strUrl"></param>
    /// <returns></returns>
    public static string UrlConvertorLocal(string strUrl)
    {
        DirectoryInfo direction = new DirectoryInfo(strUrl);
        FileInfo[] files = direction.GetFiles("*", SearchOption.TopDirectoryOnly);

        strUrl = files[0].FullName.ToString();
        return strUrl;
    }

    public static void OpenFolder(string folderPath)
    {
        var outputPath = folderPath;
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        //File.WriteAllText(Path.Combine(outputPath, "level1.txt"), "this is level one");


        if (EditorUtility.DisplayDialog("一键导出Json", "导出完成,导出目录为：" + folderPath, "打开Json文件所在目录", "确定"))
        {
            EditorUtility.RevealInFinder(outputPath);
        }
    }

}
