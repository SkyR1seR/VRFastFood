using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public int Money;
    public TMP_Text textBalance;

    private void Start()
    {
        UpdateBalance();
    }
    public void AddMoney(int count)
    {
        Money += count;
        UpdateBalance();
    }
    public void ConsumeMoney(int count)
    {
        if (Money - count < 0)
        {
            Money = 0;
        }
        else
        {
            Money -= count;
        }
        UpdateBalance();
    }
    public void UpdateBalance()
    {
        textBalance.text = "Ваш баланс: " + Money.ToString();
    }
}
