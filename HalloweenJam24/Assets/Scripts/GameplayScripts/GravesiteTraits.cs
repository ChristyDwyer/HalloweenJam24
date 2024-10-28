using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravesiteTraits : MonoBehaviour
{
    //How many objects can a gravesite see.
    [SerializeField] int itemLimit = 10;
    private int numberOfPlants = 0, numberOfWater = 0, numberOfSeats = 0, numberOfNeighbours = 0;
    public bool hasPlants = false, hasWater = false, hasSeats = false, hasNeighbours = false;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("bonk");
        if (collision.gameObject.tag == "Plant")
        {
            numberOfPlants++;
            print("A New Plant!");
        }

        if (collision.gameObject.tag == "Water")
        {
            numberOfWater++;
            print("A New Water!");
        }

        if (collision.gameObject.tag == "Neighbour")
        {
            numberOfNeighbours++;
            print("A New Neighbour!");
        }

        if (collision.gameObject.tag == "Seating")
        {
            numberOfSeats++;
            print("A New Seat!");
        }

        if (collision.gameObject.tag == "Guest")
        {
            //pass info to game about room
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Plant")
        {
            numberOfPlants--;
        }

        if (collision.gameObject.tag == "Water")
        {
            numberOfWater--;
        }

        if (collision.gameObject.tag == "Neighbour")
        {
            numberOfNeighbours--;
        }

        if (collision.gameObject.tag == "Seating")
        {
            numberOfSeats--;
        }
    }

    void Update()
    {
        if (numberOfPlants <= 0)
        {
            numberOfPlants = 0;
            hasPlants = false;
        }
        else
        {
            hasPlants = true;
        }

        if (numberOfWater <= 0)
        {
            numberOfWater = 0;
            hasWater = false;
        }
        else
        {
            hasWater = true;
        }

        if (numberOfNeighbours <= 0)
        {
            numberOfNeighbours = 0;
            hasNeighbours = false;
        }
        else
        {
            hasNeighbours = true;
        }

        if (numberOfSeats <= 0)
        {
            numberOfSeats = 0;
            hasSeats = false;
        }
        else
        {
            hasSeats = true;
        }
    }
}
