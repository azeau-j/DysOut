using System.Collections.Generic;

using Dys_The_Game.MiniGame.Letters.Ui;
using Dys_The_Game.Utils;
using UnityEngine;

namespace Dys_The_Game.MiniGame.Letters
{
    public class LettersManager : MonoBehaviour
    {
        [SerializeField] private LettersUiManager _uiManager;
        [SerializeField] private LetterWordDb _letterWordDb;
        private WordLetter _currentWordLetter;
        // private BaseReward _experienceGain;

        [Header("Game Config")]
        [SerializeField] private float _timerMax;
        private float _timer;
        private bool _isReveal;

        [SerializeField] private List<EnemyLetterGameSo> _enemies;
        private bool _isFinish;

        [SerializeField] private Unit _playerUnit;
        [SerializeField] private Unit _enemyUnit;

        // private List<BaseReward> _rewards;


        #region Unity Method

        private void Start()
        {
            Init();

            _uiManager.FirstLetterButton.onClick += Button_OnClick;
            _uiManager.SecondLetterButton.onClick += Button_OnClick;

            _uiManager.NextButton.onClick.AddListener(NextButton_OnClick);
        }

        private void Update()
        {
            HandleScore();

            if(_isReveal || _isFinish)
                return;

            if (_timer >= _timerMax)
                Reveal(false);

            _timer += Time.deltaTime;
            _uiManager.TimeBar.SetFill(1 - (_timer / _timerMax));
        }

        #endregion

        #region Callback

        private void Button_OnClick(char letter)
        {
            if (_isReveal)
                return;
            Reveal(letter == _currentWordLetter.GoodLetter);
        }

        public void NextButton_OnClick()
        {
            NextWord();
        }

        #endregion

        #region Private Method

        private void Init()
        {
            NextWord();

            ChangeEnemy();
        }

        private void NextWord()
        {
            _timer = 0;
            _isReveal = false;
            _uiManager.NextButton.interactable = false;

            _currentWordLetter = _letterWordDb.WordLetters.GetRandom(new []{_currentWordLetter});
            _uiManager.Init(_currentWordLetter.Word, _currentWordLetter.GoodLetter, _currentWordLetter.BadLetter);

            /*_rewards = new List<BaseReward> {
                new ExperienceReward(50)
            };*/
        }

        private void Reveal(bool success)
        {
            HandleGameplay(success);

            if (_isFinish)
                return;

            _isReveal = true;
            _uiManager.Reveal(success);
            _uiManager.NextButton.interactable = true;
        }

        private async void HandleScore()
        {
            if (_enemyUnit.IsDead) {
                if (_enemies.Count > 0) {
                    ChangeEnemy();
                    return;
                }

                if (!_isFinish) {
                    // List<BaseReward> rewards = await GetRewards();
                    _uiManager.ShowWin();
                }

                _isFinish = true;
            } else if (_playerUnit.IsDead) {
                _isFinish = true;
                _uiManager.ShowLose();
            }
        }

        private void HandleGameplay(bool isRight)
        {
            switch (isRight) {
                case true:
                    _playerUnit.Attack(_enemyUnit);
                    break;
                case false:
                    _enemyUnit.Attack(_playerUnit);
                    break;
            }
        }

        private void ChangeEnemy()
        {
            EnemyLetterGameSo enemy = _enemies[0];
            _enemyUnit.Init(enemy.MaxLife, enemy.Damage, enemy.Sprite, enemy.Size);
            _enemies.Remove(enemy);
        }

        /* TODO : Implement get rewards
        private List<BaseReward> GetRewards()
        {
            List<BaseReward> rewards = _rewards;

            foreach (BaseReward reward in _rewards) {
                PlayerData playerData = await PlayerData.GetData();
                reward.Get(ref playerData);
                Debug.Log(reward);
            }

            return rewards;
        }*/

        #endregion
    }
}
