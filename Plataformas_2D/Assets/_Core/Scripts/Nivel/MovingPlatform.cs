using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   public void OnCollisionEnter2D(Collision2D other) {
       GameManager.Instancia.player.transform.parent = this.transform;
   }

   public void OnCollisionExit2D(Collision2D other) {
       GameManager.Instancia.player.transform.parent = null;
   }
}
