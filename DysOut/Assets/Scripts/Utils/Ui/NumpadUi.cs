using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dys_The_Game
{
    public class NumpadUi : MonoBehaviour
    {
        [SerializeField] private Button _oneButton;
        [SerializeField] private Button _twoButton;
        [SerializeField] private Button _threeButton;
        [SerializeField] private Button _fourButton;
        [SerializeField] private Button _fiveButton;
        [SerializeField] private Button _sixButton;
        [SerializeField] private Button _sevenButton;
        [SerializeField] private Button _eightButton;
        [SerializeField] private Button _nineButton;
        [SerializeField] private Button _zeroButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _validateButton;

        private string _numberTyped = "";

        public Action<int> OnChange;
        public Action<int> OnValidate;
        
        public int NumberTyped
        {
            get { return ParseTypedNumber(); }
        }

        private void OnEnable()
        {
            _oneButton.onClick.AddListener(() => AddNumber('1'));
            _twoButton.onClick.AddListener(() => AddNumber('2'));
            _threeButton.onClick.AddListener(() => AddNumber('3'));
            _fourButton.onClick.AddListener(() => AddNumber('4'));
            _fiveButton.onClick.AddListener(() => AddNumber('5'));
            _sixButton.onClick.AddListener(() => AddNumber('6'));
            _sevenButton.onClick.AddListener(() => AddNumber('7'));
            _eightButton.onClick.AddListener(() => AddNumber('8'));
            _nineButton.onClick.AddListener(() => AddNumber('9'));
            _zeroButton.onClick.AddListener(() => AddNumber('0'));
            
            _deleteButton.onClick.AddListener(DeleteLast);
            _validateButton.onClick.AddListener(Validate);
        }

        private void OnDisable()
        {
            _oneButton.onClick.RemoveListener(() => AddNumber('1'));
            _twoButton.onClick.RemoveListener(() => AddNumber('2'));
            _threeButton.onClick.RemoveListener(() => AddNumber('3'));
            _fourButton.onClick.RemoveListener(() => AddNumber('4'));
            _fiveButton.onClick.RemoveListener(() => AddNumber('5'));
            _sixButton.onClick.RemoveListener(() => AddNumber('6'));
            _sevenButton.onClick.RemoveListener(() => AddNumber('7'));
            _eightButton.onClick.RemoveListener(() => AddNumber('8'));
            _nineButton.onClick.RemoveListener(() => AddNumber('9'));
            _zeroButton.onClick.RemoveListener(() => AddNumber('0'));
            
            _deleteButton.onClick.RemoveListener(DeleteLast);
            _validateButton.onClick.RemoveListener(Validate);
        }

        private void Start()
        {
            OnChange += value => {
                Debug.Log($"CHANGE : {value}");
            };
            
            OnValidate += value => {
                Debug.Log($"VALIDATE : {value}");
            };
        }

        private void AddNumber(char number)
        {
            _numberTyped = $"{_numberTyped}{number}";
            OnChange?.Invoke(ParseTypedNumber());
        }

        private void DeleteLast()
        {
            if (_numberTyped.Length <= 0)
                return;
            
            _numberTyped = _numberTyped.Remove(_numberTyped.Length - 1);
            OnChange?.Invoke(ParseTypedNumber());
        }

        private int ParseTypedNumber()
        {
            return int.TryParse(_numberTyped, out int value) ? value : 0;
        }

        private void Validate()
        {
            OnValidate?.Invoke(ParseTypedNumber());
        }

        public void Reset()
        {
            _numberTyped = "";
        }
    }
}
