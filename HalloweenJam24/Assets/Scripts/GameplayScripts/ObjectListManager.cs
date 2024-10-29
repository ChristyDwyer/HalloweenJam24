using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListManager : MonoBehaviour
{
    private GameObject[] temp_array;
    [SerializeField] private List<GameObject> objects = new();
    // Start is called before the first frame update
    void Awake()
    {
        temp_array = GameObject.FindGameObjectsWithTag("IntersectableObject");
        foreach(GameObject element in temp_array)
        {
            objects.Add(element);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject thing_to_add)
    {
        objects.Add(thing_to_add);
    }

    public List<GameObject> GetObjects()
    {
        return objects;
    }
}
