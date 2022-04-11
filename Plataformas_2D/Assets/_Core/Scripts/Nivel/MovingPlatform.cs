using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
       GameManager.Instancia.player.transform.parent = this.transform;
   }

   private void OnCollisionExit2D(Collision2D other) {
       GameManager.Instancia.player.transform.parent = null;
   }
}
