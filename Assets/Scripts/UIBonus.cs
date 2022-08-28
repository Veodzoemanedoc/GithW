using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace L
{
    public class UIBonus
    {
        public Text _pointLabel;
        public UIBonus(Text pointLabel)
        {
            _pointLabel = pointLabel;
            _pointLabel.text = string.Empty;
        }
        public void Display(int value)
        {
            _pointLabel.text = $"Бонусов: {value}";
        }
    }
}
