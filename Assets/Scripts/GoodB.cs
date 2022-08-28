using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace L
{
    public class GoodB : Bonus, IFly
    {
        public event Action<int> AddPoint = delegate (int i) { };

        private int _point;
        private Material _material;
        public override void Awake()
        {
            base.Awake();
            _hightFLY = 0.3f;
            _material = Renderer.material;
            _point = 1;
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _hightFLY), transform.position.z);
        }
        public override void Update()
        {
            Fly();
        }
        protected override void Interaction()
        {
            AddPoint?.Invoke(_point);
            IsInteractable = false;
        }
    }
}
