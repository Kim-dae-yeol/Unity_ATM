using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DepositStateUi : MonoBehaviour
    {
        [SerializeField] private Button button10000;
        [SerializeField] private Button button30000;
        [SerializeField] private Button button50000;
        [SerializeField] private InputField inputField;
        [SerializeField] private Button backButton;
        [SerializeField] private Button submitButton;

        private void Start()
        {
            ATM.Instance.OnStateChanged += StateChanged;
            button10000.onClick.AddListener(ATM.Instance.Deposit10000);
            button30000.onClick.AddListener(ATM.Instance.Deposit30000);
            button50000.onClick.AddListener(ATM.Instance.Deposit50000);
            backButton.onClick.AddListener(ATM.Instance.BackPress);
            inputField.onValueChanged.AddListener(ATM.Instance.OnTextChanged);
            ATM.Instance.OnInputFieldChanged += OnValueChanged;
            inputField.characterLimit = 12;
            submitButton.onClick.AddListener(ATM.Instance.Submit);
        }

        private void OnDestroy()
        {
            ATM.Instance.OnStateChanged -= StateChanged;
            button10000.onClick.RemoveAllListeners();
            button30000.onClick.RemoveAllListeners();
            button50000.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
            inputField.onValueChanged.RemoveAllListeners();
            submitButton.onClick.RemoveAllListeners();
            ATM.Instance.OnInputFieldChanged -= OnValueChanged;
        }

        private void StateChanged(AtmState state)
        {
            gameObject.SetActive(state == AtmState.DepositScreen);
        }

        private void OnValueChanged(string s)
        {
            inputField.text = s;
        }
    }
}