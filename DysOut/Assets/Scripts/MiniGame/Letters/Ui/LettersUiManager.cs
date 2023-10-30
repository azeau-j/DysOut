using System.Collections.Generic;
using Dys_The_Game.Utils;
using Dys_The_Game.Utils.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Dys_The_Game.MiniGame.Letters.Ui
{
    public class LettersUiManager : MonoBehaviour
    {
        [Header("Gameplay")]
        [SerializeField] private BarUi _timeBar;
        [SerializeField] private LetterButtonUi _firstLetterButton;
        [SerializeField] private LetterButtonUi _secondLetterButton;
        [SerializeField] private TextMeshProUGUI _wordText;

        [SerializeField] private Button _nextButton;

        [SerializeField] private RectTransform _winPanel;
        [SerializeField] private RectTransform _losePanel;

        [Header("Win Panel")]
        [SerializeField] private RectTransform _rewardsHolder;
        [SerializeField] private TextMeshProUGUI _rewardTextTemplate;

        private LetterButtonUi _goodButton;
        private LetterButtonUi _badButton;

        #region Getter & Setter

        public LetterButtonUi FirstLetterButton
        {
            get { return _firstLetterButton; }
        }

        public LetterButtonUi SecondLetterButton
        {
            get { return _secondLetterButton; }
        }

        public Button NextButton
        {
            get { return _nextButton; }
        }

        public BarUi TimeBar
        {
            get { return _timeBar; }
        }

        #endregion

        #region Unity Method

        private void Awake()
        {
            _goodButton = _firstLetterButton;
            _badButton = _secondLetterButton;
            
            _winPanel.gameObject.SetActive(false);
            _losePanel.gameObject.SetActive(false);
        }
        
        #endregion

        #region Public Method

        public void Init(string word, char goodLetter, char badLetter)
        {
            _goodButton.SetColor(Color.white);
            _badButton.SetColor(Color.white);
            
            _wordText.text = word.Replace(goodLetter, '_');

            int randomNumber = Random.Range(1, 3);

            if (randomNumber == 1) {
                _firstLetterButton.SetLabel(goodLetter);
                _goodButton = _firstLetterButton;
                _secondLetterButton.SetLabel(badLetter);
                _badButton = _secondLetterButton;
            } else {
                _firstLetterButton.SetLabel(badLetter);
                _badButton = _firstLetterButton;
                _secondLetterButton.SetLabel(goodLetter);
                _goodButton = _secondLetterButton;
            }
        }

        public void Reveal(bool success)
        {
            string textColor = success ? "#008000ff" : "#800000ff";
            _wordText.text = _wordText.text.Replace("_", _goodButton.Label).Color(textColor);

            _goodButton.SetColor(Color.green);

            if (!success)
                _badButton.SetColor(Color.red);
        }

        public void ShowWin()
        {
            _winPanel.gameObject.SetActive(true);
        }
        
        public void ShowLose()
        {
            _losePanel.gameObject.SetActive(true);
        }

        #endregion
    }
}