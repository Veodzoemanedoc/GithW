using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace L
{
    public class BadB : Bonus, IRotation, IFlick
    {
        public event Action<string, Color> OnGameOver = delegate (string str, Color color) { };
        private float _sr;
        private Material _material;
        public override void Awake()
        {
            base.Awake();
            _hightFLY = Random.Range(1f, 4f);
            _sr = Random.Range(25f, 40f);
            _material = Renderer.material;
        }
        protected override void Interaction()
        {
            OnGameOver?.Invoke(gameObject.name, _color);
        }
        public void Rotate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _sr, Space.World);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
        public override void Update()
        {
            Rotate();
            Flick();
        }
    }
}
