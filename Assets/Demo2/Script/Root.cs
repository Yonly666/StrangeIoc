using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo2
{
    public class Root : ContextView
    {

        private void Awake()
        {
            this.context = new Context(this);
        }
    }
}