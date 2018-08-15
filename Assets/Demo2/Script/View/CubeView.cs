using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Demo2
{
    public class CubeView : View
    {
        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        private Text cubeText;

        public void Init()
        {
            cubeText = transform.GetComponentInChildren<Text>();
        }

        private void Update()
        {
            transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * Time.deltaTime);
        }

        public void OnMouseDown()
        {
            //加分
            dispatcher.Dispatch(MediatorEvent.AddScore);
        }

        public void UpdateScore(int score)
        {
            cubeText.text = score.ToString();
        }
    }
}