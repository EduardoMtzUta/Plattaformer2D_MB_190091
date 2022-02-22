using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoverObjeto : MonoBehaviour
{
    public GameObject posicionInicial;
    public GameObject posicionFinal;
    public GameObject objetoAMover;
    public float tiempo;
    void Start()
    {
        objetoAMover.transform.position = posicionInicial.transform.position;
        objetoAMover.transform.DOMove(posicionFinal.transform.position, tiempo).SetLoops(-1,LoopType.Yoyo);
    }
}
