using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class Cash : MonoBehaviour
    {
        [SerializeField] private Text text;
        private ATM _atm;

        private void Start()
        {
            ATM.Instance.OnCashChanged += ChangeText;
        }

        private void OnDestroy()
        {
            if (_atm != null) _atm.OnCashChanged -= ChangeText;
        }

        private void ChangeText(int money)
        {
            text.text = ATM.BalanceHeader + $"{money:N0}";
        }
    }
}