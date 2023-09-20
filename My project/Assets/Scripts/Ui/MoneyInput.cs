using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyInput : MonoBehaviour
{
    private InputField _input;

    private void Awake()
    {
        _input = GetComponent<InputField>();
    }

    public void Start()
    {
        _input.characterValidation = InputField.CharacterValidation.Decimal;
        _input.onValueChanged.AddListener(ATM.Instance.OnTextChanged);
    }

    private void OnDestroy()
    {
        _input.onValueChanged.RemoveListener(ATM.Instance.OnTextChanged);
    }
}