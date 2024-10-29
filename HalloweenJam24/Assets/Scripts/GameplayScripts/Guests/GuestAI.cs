using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GuestAI : MonoBehaviour
{
    public bool isFollowing = false;
    public bool inSpot = true;
    public GameObject player;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float personalSpace = 0.5f;
    [SerializeField] private float spotClamp = 0.1f;
    [SerializeField] private Vector3 nextSpot = Vector3.zero;
    private void FixedUpdate()
    {
        if (isFollowing)
        {
            HandleMovementPlayer();
        }
        else if (!inSpot)
        {
            HandleMovementQueue();
        }
    }

    public void SetNextSpot(Vector3 target)
    {
        if (inSpot)
        {
            nextSpot = target;
            inSpot = false;
        }
    }
    private void HandleMovementPlayer()
    {
        Vector3 distanceVector = transform.position - player.transform.position;
        if (distanceVector.magnitude > personalSpace)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
    private void HandleMovementQueue()
    {
        Vector3 distanceVector = transform.position - nextSpot;
        if (distanceVector.magnitude > spotClamp)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextSpot, step);
        }
        else
        {
            inSpot = true;
            transform.position = nextSpot;
        }
    }
}
