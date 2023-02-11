using System.Collections;
using System.Collections.Generic;
using Services.Progress;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   [Inject] private ProgressService _service;

   private void Start()
   {
      Debug.Log(_service.PlayerData.MaxHealth);
   }
}
