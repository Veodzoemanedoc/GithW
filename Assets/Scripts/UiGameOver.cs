using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace L
{
    public class UiGameOver
    {
        private Text _GOLabel;

        public UiGameOver(Text GOLabel)
        {
            _GOLabel = GOLabel;
            _GOLabel.text = string.Empty;

        }
        public void GameOver(string name, Color color)
        {
            _GOLabel.text = $"GG {name} + {color}";
    }

    }

}
