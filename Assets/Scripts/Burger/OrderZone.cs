using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderZone : MonoBehaviour
{
    public List<Food> currentList;
    public List<Food> orderList;

    public List<Food> foodList;
    public List<Food> trayList;

    public TMP_Text orderText;

    public Balance balance;

    private void Start()
    {

    }

    public void CompleteOrder()
    {
        int error=0;

        List<Food> checkList = new List<Food>(orderList);
        foreach (var item in orderList) 
        {
            if (currentList.Find(x=>x.foodName == item.foodName))
            {
                checkList.Remove(item);
            }
            else
            {
                error++;
            }
        }

        if (checkList.Count == 0 && orderList.Count == currentList.Count)
        {
            foreach (var item in currentList)
            {
                Destroy(item.gameObject);
            }
            currentList.Clear();

            currentBot.GoToExit();
            Debug.Log("Заказ выполнен правильно");
            balance.AddMoney(orderList.Count*10);
        }
        else
        {
            Debug.Log("Заказ выполнен неправильно");
            balance.ConsumeMoney(orderList.Count);
        }
    }

    Bot currentBot;
    public void GenerateOrder(Bot bot)
    {
        currentBot = bot;
        orderList.Clear();
        orderText.text = "Заказ:";
        Food tray = trayList[Random.Range(0, trayList.Count - 1)];
        orderText.text += "\n" + tray.foodName;
        orderList.Add(tray);
        for (int i = 0; i < Random.Range(1,8); i++)
        {
            Food food = foodList[Random.Range(0, foodList.Count - 1)];
            orderText.text += "\n" + food.foodName;
            orderList.Add(food);
        }
    }

    private void AddFoodInOrder(Food food)
    {
        currentList.Add(food);
    }
    private void RemoveFoodInOrder(Food food)
    {
        currentList.Remove(food);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            AddFoodInOrder(other.GetComponent<Food>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            RemoveFoodInOrder(other.GetComponent<Food>());
        }
    }
}
