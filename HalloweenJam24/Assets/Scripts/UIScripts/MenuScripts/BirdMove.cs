using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    [SerializeField] int birdTime = 550;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < 2000)
         {
            this.transform.Translate(Vector3.right * Time.deltaTime* birdTime);
         }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
