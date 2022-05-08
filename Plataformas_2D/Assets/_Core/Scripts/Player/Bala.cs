using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    void Start()
    {
        rb.velocity = transform.right * speed;
        //Hacer las balas de bomba
        //Lanzamiento en parabola, lanzamiento en X y en Y
        //Dejar activada la gravedad
        // agregar fuerza rb.AddForce
    }
}
