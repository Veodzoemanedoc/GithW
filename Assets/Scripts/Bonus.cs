using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace L
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;

        public float _hightFLY;

        public bool IsInteractable 
        {
            get => IsInteractable;
            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;

            }
        }

        public Renderer Renderer { get => _renderer; set => _renderer = value; }

        public virtual void Awake()
        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("Нет Компонента Renderer");
            }

            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("Нет Компонента Collider");
            }
            IsInteractable = true;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
            }
        }


        protected abstract void Interaction();
        public abstract void Update();
    }
}
