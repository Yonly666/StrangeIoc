using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    /// <summary>
    /// Root,整个程序的入口
    /// </summary>
    public class ContextViewRoot : ContextView
    {

        private void Awake()
        {
            this.context = new Context(this);
        }

    }
}