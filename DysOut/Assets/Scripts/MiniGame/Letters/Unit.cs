using UnityEngine;
using UnityEngine.UI;

namespace Dys_The_Game.MiniGame.Letters
{
    [RequireComponent(typeof(Animator))]
    public class Unit : MonoBehaviour
    {
        private Animator _animator;

        [SerializeField] private Image _visual;
        [SerializeField] private Image _bar;

        [SerializeField] private int _maxLife;
        private int _currentLife;
        private int _damage = 1;

        private Unit _unitToAttack;

        public bool IsDead
        {
            get { return _currentLife <= 0; }
        } 
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _bar.fillAmount = 1;
            _currentLife = _maxLife;
        }

        public void Init(int maxLife, int damage, Sprite sprite, int size)
        {
            _maxLife = maxLife;
            _currentLife = _maxLife;
            _bar.fillAmount = 1;

            _damage = damage;
            
            _visual.enabled = true;
            _visual.sprite = sprite;
            
            RectTransform rectTransform = _visual.rectTransform;
            rectTransform.sizeDelta = new Vector2(size, rectTransform.sizeDelta.y);
        }

        public void TakeDamage(int amount)
        {
            _currentLife -= amount;

            if (_currentLife <= 0) {
                _visual.enabled = false;
            }
            
            _bar.fillAmount = (float)_currentLife / _maxLife;
        }

        public void Attack(Unit unitToAttack)
        {
            _unitToAttack = unitToAttack;
            _animator.SetTrigger(UnitAnimatorParams.Attack);
        }

        public void AttackEvent()
        {
            if (_unitToAttack != null)
                _unitToAttack.TakeDamage(_damage);
            _unitToAttack = null;
        }
    }

    public static class UnitAnimatorParams
    {
        public static int Attack
        {
            get { return Animator.StringToHash("Attack");  }
        }
    }
}