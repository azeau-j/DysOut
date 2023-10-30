using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dys_The_Game.MiniGame.Letters
{
    [RequireComponent(typeof(Button))]
    public class LetterButtonUi : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private TextMeshProUGUI _label;

        public Action<char> onClick;

        public string Label
        {
            get { return _label.text; }
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            onClick?.Invoke(_label.text[0]);
        }

        public void SetLabel(char label)
        {
            _label.text = label.ToString();
        }

        public void SetColor(Color color)
        {
            ColorBlock buttonColor = _button.colors;
            buttonColor.normalColor = color;
            buttonColor.selectedColor = color;
            buttonColor.disabledColor = color;
            
            _button.colors = buttonColor;
        }
    }
}