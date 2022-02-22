using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float velocidad;
    public float salto;
    private float horizontal;
    public bool estaEnSuelo;
    public bool bloquearMovimiento = false;
    void Start()
    {

    }
    public void Bloquearcorrida(){
        bloquearMovimiento = true;
        rb.velocity = Vector2.zero;
    }
    void Update()
    {
        if (bloquearMovimiento)
        {
            return;
        }

        ChecarSalto();
        ChecarMovimiento();
        ChecarSuelo();
        Voltear();

        anim.SetBool("IsJumping", !estaEnSuelo);
    }
    private void ChecarMovimiento()
    {

        //Derecha Izquierda
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);

        anim.SetBool("IsMoving", horizontal != 0);
    }
    private void ChecarSalto()
    {

        //Arriba Abajo
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, salto);
        }
    }

    private void ChecarSuelo()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {
            estaEnSuelo = true;
        }
        else
        {
            estaEnSuelo = false;
        }
    }
    public bool estaVolteandoDerecha = true;
    private void Voltear()
    {
        if((horizontal < 0 && estaVolteandoDerecha) || (horizontal > 0 && !estaVolteandoDerecha)){
        estaVolteandoDerecha = !estaVolteandoDerecha;
        transform.Rotate(0, 180, 0);
        }
    }
}
