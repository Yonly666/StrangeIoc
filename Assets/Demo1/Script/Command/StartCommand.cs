using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public class StartCommand : Command
    {
        [Inject]
        public AudioManager audioManager { get; set; }

        public override void Execute()
        {
            Debug.Log("Demo1StartCommand");
            //manager 执行初始化
            audioManager.Init();
        }
    }
}