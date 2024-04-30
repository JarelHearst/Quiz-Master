using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
   Timer timer;
   void Start()
   {
      timer = FindObjectOfType<Timer>();
      timer.CancelTimer();


   }
   //:P
}
