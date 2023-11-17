using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public Transform spawnDot;
    public Transform orderDot;

    public List<Bot> bots = new List<Bot>();

    private void Start()
    {
        SpawnBot();
    }
    public void SpawnBot()
    {
        Bot randomBot = bots[Random.Range(0, bots.Count)];
        randomBot = Instantiate(randomBot, spawnDot.position, spawnDot.rotation);
        randomBot.SetInfo(spawnDot, orderDot);
    }
}
