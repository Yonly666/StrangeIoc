using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo2
{
    public class StartCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("start");
        }

    }
}