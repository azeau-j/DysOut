using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dys_The_Game.Utils.Ui
{
    [RequireComponent(typeof(Button))]
    public class ButtonUi : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private TextMeshProUGUI _label;

        private Action _onClick;

        #region Unity Method

        private void Awake()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(Button_OnClick);
        }

        #endregion
        
        #region Public Method

        public void SetOnClick(Action onClick)
        {
            _onClick = onClick;
        }

        public void SetLabel(string label)
        {
            _label.text = label;
        }

        #endregion

        #region Private Method

        private void Button_OnClick()
        {
            _onClick?.Invoke();
        }

        #endregion
    }
}