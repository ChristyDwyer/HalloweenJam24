using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandling : MonoBehaviour
{
    public bool is_placed_down = false;
    private ObjectListManager object_manager;
    private Collider loc_collider;
    public bool intersects = false;
    // Start is called before the first frame update
    void Start()
    {
        object_manager = FindObjectOfType<ObjectListManager>();
        loc_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_placed_down)
        { 
            int intersection_points = 0;

            foreach (GameObject place in object_manager.GetObjects())
            {
                if (loc_collider.bounds.Intersects(place.GetComponent<Collider>().bounds))
                {
                    intersection_points++;
                }
                if (intersection_points > 0)
                {
                    intersects = true;
                }
                else
                {
                    intersects = false;
                }
            }

        }
    }
}
