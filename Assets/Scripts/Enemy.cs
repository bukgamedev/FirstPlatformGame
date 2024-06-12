using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float MovementDistance;
    public float Speed;
    public float damage;
    public bool movingleft;
    private float leftedge;
    private float rightedge;
    private void Awake()
    {
        leftedge = transform.position.x - MovementDistance;
        rightedge = transform.position.x + MovementDistance;
    }
    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = false;
            }
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(damage);
        }
    }
}
