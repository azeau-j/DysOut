using UnityEngine;
using UnityEngine.UI;

namespace Dys_The_Game.Utils.Ui
{
    public class BarUi : MonoBehaviour
    {
        [SerializeField] private Image _fill;

        public void SetFill(float fill)
        {
            _fill.fillAmount = fill;
        }
    }
}