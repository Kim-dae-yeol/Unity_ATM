using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class WithdrawStateUi : MonoBehaviour
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
            button10000.onClick.AddListener(ATM.Instance.Withdraw10000);
            button30000.onClick.AddListener(ATM.Instance.Withdraw30000);
            button50000.onClick.AddListener(ATM.Instance.Withdraw50000);
            backButton.onClick.AddListener(ATM.Instance.BackPress);
            inputField.onValueChanged.AddListener(ATM.Instance.OnTextChanged);
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
            submitButton.onClick.RemoveAllListeners();
            inputField.onValueChanged.RemoveAllListeners();
        }

        private void StateChanged(AtmState state)
        {
            gameObject.SetActive(state == AtmState.WithdrawScreen);
        }
    }
}