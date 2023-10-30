using System.Collections.Generic;
using UnityEngine;

namespace Dys_The_Game.MiniGame.Letters
{
    [CreateAssetMenu(fileName="newLetterWordDb", menuName="Data/LetterWordDb")]
    public class LetterWordDb : ScriptableObject
    {
        [SerializeField] public List<WordLetter> WordLetters;

        public WordLetter GetWord(int id)
        {
            return id >= WordLetters.Count ? default : WordLetters[id];
        }

        public void CreateEmptyWord()
        {
            WordLetters.Add(new WordLetter {
                Word = "Word",
                GoodLetter = 'A',
                BadLetter = 'B'
            });
        }

        public void RemoveWord(WordLetter difficulty)
        {
            WordLetters.Remove(difficulty);
        }

        public int GetLastId() => WordLetters.Count - 1;

    }
    
    [System.Serializable]
    public struct WordLetter
    {
        public string Word;
        public char GoodLetter;
        public char BadLetter;

        public override string ToString()
        {
            return Word;
        }

        public string GetDisplayName()
        {
            return $"{Word} - {GoodLetter}/{BadLetter}";
        }
    }
}