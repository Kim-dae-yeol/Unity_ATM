using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ErrorPopUp : MonoBehaviour
    {
        [SerializeField] private Button okButton;
        [SerializeField] private Text msgText;

        private void Start()
        {
            ATM.Instance.OnError += OnError;
            okButton.onClick.AddListener(() => { gameObject.SetActive(false); });
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            ATM.Instance.OnError -= OnError;
            okButton.onClick.RemoveAllListeners();
        }

        private void OnError(string msg)
        {
            msgText.text = msg;
            gameObject.SetActive(true);
        }
    }
}