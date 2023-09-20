using System;
using System.Collections;
using System.Collections.Generic;
using Ui;
using Unity.VisualScripting;
using UnityEngine;

public enum AtmState
{
    HomeScreen,
    DepositScreen,
    WithdrawScreen
}

/// <summary>
///  UI 상태와 통장 잔액과 현금상태를 저장하는 개체  
/// </summary>
public class ATM : MonoBehaviour
{
    public static ATM Instance;

    public const string BalanceHeader = "<b>Balance</b> ";
    private const string ErrorMessage = "잔액이 부족합니다.";

    //Current Money States
    [SerializeField] private int _cash = 100_000;
    public int Cash => _cash;

    [SerializeField] private int _balance = 250_000;
    public int Balance => _balance;

    //UiState
    private AtmState _currentState = AtmState.HomeScreen;

    private string _inputText = string.Empty;

    // 2 way data binding 
    public string InputText
    {
        set
        {
            if (string.IsNullOrEmpty(value) || value == _inputText) return;
            var newMoney = value.Replace(",", "");
            if (int.TryParse(newMoney, out var money))
            {
                if (newMoney != _inputText)
                {
                    _inputText = newMoney;
                    OnInputFieldChanged?.Invoke($"{money:N0}");
                }
            }
            else
            {
                // validation failed
                OnInputFieldChanged?.Invoke(_inputText);
            }
        }
    }

    public event Action<int> OnCashChanged;
    public event Action<int> OnBalanceChanged;
    public event Action<string> OnError;
    public event Action<AtmState> OnStateChanged;
    public event Action<string> OnInputFieldChanged;

    private bool _isUiUpdated = false;

    private AtmUI _ui;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        var uiObj = Resources.Load("Prefabs/UI");
        var go = Instantiate(uiObj);
        _ui = go.GetComponent<AtmUI>();
    }

    private void Update()
    {
        if (!_ui.IsReady || _isUiUpdated) return;
        Refresh();
    }

    private void Withdraw(int money)
    {
        //출금
        if (_balance < money)
        {
            OnError?.Invoke(ErrorMessage);
            return;
        }

        _cash += money;
        _balance -= money;
        _isUiUpdated = false;
    }

    private void Deposit(int money)
    {
        //입금
        if (_cash < money)
        {
            OnError?.Invoke(ErrorMessage);
            return;
        }

        _cash -= money;
        _balance += money;
        _isUiUpdated = false;
    }

    private void CallCashChange()
    {
        OnCashChanged?.Invoke(_cash);
    }

    private void CallBalanceChange()
    {
        OnBalanceChanged?.Invoke(_balance);
    }

    private void Refresh()
    {
        _isUiUpdated = true;
        CallCashChange();
        CallBalanceChange();
        OnStateChanged?.Invoke(_currentState);
    }

    public void Deposit10000()
    {
        Deposit(10000);
    }

    public void Deposit30000()
    {
        Deposit(30000);
    }

    public void Deposit50000()
    {
        Deposit(50000);
    }


    public void Withdraw10000()
    {
        Withdraw(10000);
    }

    public void Withdraw30000()
    {
        Withdraw(30000);
    }

    public void Withdraw50000()
    {
        Withdraw(50000);
    }

    public void BackPress()
    {
        // 복잡해지는 화면의 경우는 이전 화면으로의 네비게이션을 위해서 스택을 사용
        ChangeState(AtmState.HomeScreen);
    }

    public void OnTextChanged(string text)
    {
        InputText = text;
    }

    public void ChangeState(AtmState state)
    {
        InputText = string.Empty;
        _currentState = state;
        _isUiUpdated = false;
    }

    public void Submit()
    {
        var isValid = int.TryParse(_inputText, out var money);
        if (!isValid) return;

        switch (_currentState)
        {
            case AtmState.WithdrawScreen:
                Withdraw(money);
                break;
            case AtmState.DepositScreen:
                Deposit(money);
                break;
            default: throw new Exception("현재 상태가 입금 또는 출금 상태에서만 가능한 동작입니다.");
        }
    }
}