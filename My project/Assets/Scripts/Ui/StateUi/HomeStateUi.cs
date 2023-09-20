using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class HomeStateUi : MonoBehaviour
    {
        [SerializeField] private Button _depositButton;
        [SerializeField] private Button _witdhrawButton;
        

        private void Start()
        {
            ATM.Instance.OnStateChanged += OnStateChanged;
            _depositButton.onClick.AddListener(() => ChangeState(AtmState.DepositScreen));
            _witdhrawButton.onClick.AddListener(() => ChangeState(AtmState.WithdrawScreen));
        }

        private void OnDestroy()
        {
            _depositButton.onClick.RemoveAllListeners();
            _witdhrawButton.onClick.RemoveAllListeners();
        }

        private void OnStateChanged(AtmState state)
        {
            gameObject.SetActive(state == AtmState.HomeScreen);
        }

        private void ChangeState(AtmState state)
        {
            ATM.Instance.ChangeState(state);
        }
    }
}