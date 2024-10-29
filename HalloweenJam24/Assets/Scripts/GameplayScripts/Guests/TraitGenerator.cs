using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TraitGenerator : MonoBehaviour
{
    int trait1 = 0, trait2 = 0;
    int weight1 = 0, weight2 = 0;

    string[] traits = { "Plants", "Water", "Neighbours", "Seating" }; 

    // Start is called before the first frame update
    void Awake()
    {
        GenerateTraits();
        GetTraits();
    }

    public void GenerateTraits()
    {
        trait1 = Random.Range(0, 4);
        trait2 = Random.Range(0, 4);

        while (trait1 == trait2)
        {
            trait2 = Random.Range(0, 4);
        }

        weight1 = Random.Range(1, 5);
        weight2 = Random.Range(1, 5);
    }

    public void GetTraits()
    {
        switch (weight1)
        {
            case 1:
                
                print("I hate " + traits[trait1]);

                break;

            case 2:

                print("I don't like " + traits[trait1]);

                break;

            case 3:

                print("I like " + traits[trait1]);

                break;

            case 4:

                print("I love " + traits[trait1]);

                break;

        }

        print("/n");

        switch (weight2)
        {
            case 1:

                print("I hate " + traits[trait2]);

                break;

            case 2:

                print("I don't like " + traits[trait2]);

                break;

            case 3:

                print("I like " + traits[trait2]);

                break;

            case 4:

                print("I love " + traits[trait2]);

                break;

        }
    }
}
