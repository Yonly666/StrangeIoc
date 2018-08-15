/// A Signal which hands back an URL
/// 
/// string The URL

using System;
using strange.extensions.signal.impl;

namespace strange.examples.signals
{
    /// <summary>
    /// 实现Web服务请求信号
    /// </summary>
	public class FulfillWebServiceRequestSignal : Signal<string>
	{
	}
}

