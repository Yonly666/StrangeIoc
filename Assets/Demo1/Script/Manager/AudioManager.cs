using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public class AudioManager
    {

        private static string audioTextPathPrefix = Application.dataPath + "\\Demo3_AudioMgr\\Resources\\";
        private const string audioTextPathMeddlefix = "AudioList";
        private const string audioTextPathPostfix = ".txt";

        public static string AudioTextPath
        {
            get { return audioTextPathPrefix + audioTextPathMeddlefix + audioTextPathPostfix; }
        }

        public Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

        private bool isMute = false;
        //是否静音
        public bool IsMute
        {
            get { return isMute; }
            set { isMute = value; }
        }

        public void Init()
        {
            LoadAudioClip();
        }

        private void LoadAudioClip()
        {
            audioClipDict = new Dictionary<string, AudioClip>();
            TextAsset ta = Resources.Load<TextAsset>(audioTextPathMeddlefix);
            string[] lines = ta.text.Split('\n');
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] keyValue = line.Split(',');
                    string key = keyValue[0];
                    AudioClip value = Resources.Load<AudioClip>(keyValue[1]);
                    audioClipDict.Add(key, value);
                }
            }
        }

        public void Play(string name)
        {
            if (isMute) return;
            AudioClip clip;
            audioClipDict.TryGetValue(name, out clip);
            if (clip)
            {
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            }
        }

        public void Play(string name, Vector3 playPos)
        {
            if (isMute) return;
            AudioClip clip;
            audioClipDict.TryGetValue(name, out clip);
            if (clip)
            {
                AudioSource.PlayClipAtPoint(clip, playPos);
            }
        }
    }
}