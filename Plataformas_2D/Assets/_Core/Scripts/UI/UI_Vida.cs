using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Vida : MonoBehaviour
{
   public Image vidaImage;
   public Sprite vidaOn;
   public Sprite vidaOff;

   public void ApagarVida(){
       vidaImage.sprite = vidaOff;
   } 

   public void PrenderVida(){
       vidaImage.sprite = vidaOn;
   } 
}
