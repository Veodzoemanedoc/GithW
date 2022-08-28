using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using L;

namespace L
{
    public class NewUser : IRotation
    {
        private string _name;
        private int _health;
        private int _id;
        public NewUser(string name, int health, int id)
        {
            _name = name;
            _health = health;
            _id = id;
            Debug.Log("Новый игрок: " + name);
        }

        delegate int Summ(int num);

        Summ Mydelegate = delegate (int val)
        {
            int result = 0;
            for (int i = 0; i <= val; i++)
            {
                result += i;
            }
            return result;
        };



        public void Rotate()
        {

        }
        public void Move(int x, int y)
        {

        }
    }

    public class Temp : MonoBehaviour
    {
        NewUser myClass;

        void Start()
        {
            myClass = new NewUser("Пользователь1", 100, 1);
        }

    }
}
