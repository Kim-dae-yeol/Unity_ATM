using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Balance : MonoBehaviour
    {
        [SerializeField] private Text text;
        private ATM _atm;

        private void Start()
        {
            ATM.Instance.OnBalanceChanged += ChangeText;
        }

        private void OnDestroy()
        {
            if (_atm != null) _atm.OnBalanceChanged -= ChangeText;
        }

        private void ChangeText(int money)
        {
            text.text = ATM.BalanceHeader + $"{money:N0}";
        }
    }
}