using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogScript : MonoBehaviour
{
    [SerializeField] private Animator HedgeAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SliderChange"))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            var motor = GetComponent<SliderJoint2D>().motor;
            motor.motorSpeed *= -1;
            GetComponent<SliderJoint2D>().motor = motor; 
        }
        if (collision.CompareTag("Player"))
        {
            HedgeAnim.SetTrigger("Attack");
        }
    }
}
