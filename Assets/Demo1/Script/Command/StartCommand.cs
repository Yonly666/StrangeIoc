using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public class StartCommand : Command
    {


        public override void Execute()
        {
            Debug.Log("Demo1StartCommand");
        }
    }
}