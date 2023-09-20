using System;
using UnityEngine;

namespace Ui
{
    public class AtmUI : MonoBehaviour
    {
        public bool IsReady { get; private set; }

        private void Start()
        {
            IsReady = true;
        }
    }
}