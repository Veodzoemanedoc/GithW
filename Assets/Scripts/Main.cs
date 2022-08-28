using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace L
{
    public class Main : MonoBehaviour
    {
        private int _bonusCount;
        IEnumerator IE;

        [SerializeField] private Unit _player;
        [SerializeField] private Bonus[] BonusObj;
        [SerializeField] private Text _pointlabel;
        [SerializeField] private Text _GOLabel;
        [SerializeField] private Button _restartButton;

        private InputController _inputController;
        private ListExecuteUnitController _executeObj;

        private UIBonus _DBonus;
        private UiGameOver _DGO;


        private void Awake()
        {

            Time.timeScale = 1f;
            _inputController = new(_player);

            _executeObj = new ListExecuteUnitController(BonusObj);
            _executeObj.AddExecuteObject(_inputController);

            _DBonus = new UIBonus(_pointlabel);
            _DGO = new UiGameOver(_GOLabel);


            IE = _executeObj.GetEnumerator();

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
            foreach (var item in BonusObj)
            {
                if (item is GoodB goodB)
                {
                    goodB.AddPoint += AddPoints;
                }
                if (item is BadB badB)
                {
                    badB.OnGameOver += GameOver;
                    badB.OnGameOver += _DGO.GameOver;

                }
            }

            
        }

        private void AddPoints(int value)
        {
            _bonusCount += value;
            _DBonus.Display(_bonusCount);
        }
        private void GameOver(string value, Color color)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        private void Update()
        {
            
            for (int i = 0; i < _executeObj.Length; i++)
            {
                if (_executeObj[i] == null)
                {
                    continue;
                }
                _executeObj[i].Update();
            }
        }
    }

}
