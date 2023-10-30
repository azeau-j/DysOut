using Dys_The_Game.MiniGame.Letters;
using UnityEngine;

namespace Dys_The_Game.MiniGame.Letters
{
    [CreateAssetMenu(fileName="newEnemyLetterGameSo", menuName="Data/Enemy Letter Game")]
    public class EnemyLetterGameSo : ScriptableObject
    {
        [SerializeField] private string _name;
        
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _size = 200;

        [SerializeField] private int _maxLife;
        [SerializeField] private int _damage = 1;

        public string Name
        {
            get { return _name; }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
        }

        public int Size
        {
            get { return _size; }
        }

        public int MaxLife
        {
            get { return _maxLife; }
        }

        public int Damage
        {
            get { return _damage; }
        }
    }
}