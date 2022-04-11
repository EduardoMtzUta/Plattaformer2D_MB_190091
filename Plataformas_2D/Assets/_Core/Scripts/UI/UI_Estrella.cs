using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Estrella : MonoBehaviour
{
    public Image imagen;
   public void PrenderEstrella(){
       imagen.color = Color.white;
       transform.DOPunchScale(new Vector3(0.3f,0.3f,0.3f),3.0f);
   }
   public void ApagarEstrella(){
       imagen.color = Color.gray;
   }
}
