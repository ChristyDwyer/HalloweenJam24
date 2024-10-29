using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public int currentGuests = 0;
    public float spawnTimer = 5f;
    [SerializeField] private List<GuestAI> guestList = new List<GuestAI>();
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 spawnTime = Vector2.zero;
    [SerializeField] private int maxGuests = 4;
    [SerializeField] private GameObject guestPrefab;
    [SerializeField] private List<Transform> spawnpoints = new();

    private void Awake()
    {
       
    }
    private void FixedUpdate()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            SpawnGuest();
        }
    }
    private void SpawnGuest()
    {
        if (currentGuests < maxGuests)
        {
            //This is bad and wrong and will need to be changed when models are more than simple shapes :)
            var guest = Instantiate(guestPrefab, spawnpoints[currentGuests]);
            guest.GetComponent<GuestAI>().player = player;
            guestList.Add(guest.GetComponent<GuestAI>());
            currentGuests++;
        }
        spawnTimer = Random.Range(spawnTime.x, spawnTime.y);
    }
    public void NextGuest()
    {
        if(currentGuests > 0)
        {
            spawnTimer += 2;
            currentGuests--;
            guestList.RemoveAt(0);
            MoveQueue();
            //Smove Queue
        }
    }
    private void MoveQueue()
    {
        for (int i = 0; i < currentGuests; i++)
        {
            guestList[i].SetNextSpot(spawnpoints[i].position);
        }
    }
}
