using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SliderChange"))
        {
            var motor = GetComponent<SliderJoint2D>().motor;
            motor.motorSpeed *= -1;
            GetComponent<SliderJoint2D>().motor = motor; //Почему юнька не хочет напрямую менять переменную?
        }
    }
}
