using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField] GameObject bird;
    private float timer = 30;
    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            timer = Random.Range(30, 80);
            Instantiate(bird, this.transform.position, this.transform.rotation, this.gameObject.transform.parent);
        }

        timer = timer - Time.deltaTime;
    }
}
