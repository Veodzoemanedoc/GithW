using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace L
{
    public abstract class Unit : MonoBehaviour
    {

        public Transform _transform;
        public Rigidbody _rb;

        private int _health = 100;
        private bool _isDead;

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    _health = Health;
                }
                else
                {
                    _health = 1;
                }
            }
        }

        public virtual void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("Нет Компонента Transform");
            }

            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("Нет Компонента RB");
            }
        }
        public abstract void Move(float x, float y, float z);
    }
    
}