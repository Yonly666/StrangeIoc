using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

public class AudioWindowEditor : EditorWindow
{

    [MenuItem("Manager/AudioManager")]
    static void AudioManager()
    {
        //EditorAudioWindow editorWindow = GetWindowWithRect<EditorAudioWindow>(new Rect(400, 400, 300, 400));
        AudioWindowEditor editorWindow = EditorWindow.GetWindow<AudioWindowEditor>("音频管理器");
        editorWindow.minSize = new Vector2(200, 200);
        editorWindow.Show();
    }

    private string audioName;
    private string audioPath;
    private string savePath;
    private Dictionary<string, string> audioDict;
    private void OnEnable()
    {
        savePath = Application.dataPath + "\\Demo1\\Resources\\AudioList.txt";
        audioDict = new Dictionary<string, string>();
        LoadAudioList();
    }
    
    //窗口被更新时调用
    private void OnInspectorUpdate()
    {
        LoadAudioList();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音频名称");
        GUILayout.Label("音频路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();

        //遍历字典已存的
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音频名称", audioName);
        audioPath = EditorGUILayout.TextField("音频路径", audioPath);
        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("添加失败，路径: + " + audioPath + " 不存在");
                audioPath = "";
                return;
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("音频名字已存在");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
            }
        }
    }
    
    void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }
        System.IO.File.WriteAllText(savePath, sb.ToString());
    }

    void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();
        if (System.IO.File.Exists(savePath) == false) return;
        string[] lines = System.IO.File.ReadAllLines(savePath);
        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] keyValue = line.Split(',');
                audioDict.Add(keyValue[0], keyValue[1]);
            }
        }
    }
}
