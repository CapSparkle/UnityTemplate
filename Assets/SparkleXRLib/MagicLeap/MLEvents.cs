using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.MagicLeap;

#if PLATFORM_LUMIN
namespace SparkleXRLib.MagicLeap
{
    public class MLEvents : MonoBehaviour
    {
        public UnityEvent BumperEvent;

        MLInput.Controller controller;
        void Start()
        {
            MLInput.Start();
            controller = MLInput.GetController(0);
            controller.OnButtonDown += HandlePress;
        }

        public void HandlePress(byte controllerId, MLInput.Controller.Button pressedButton)
        {
            if (controllerId == controller.Id && pressedButton == MLInput.Controller.Button.Bumper)
            {
                BumperEvent.Invoke();
            }
        }
    }
}
#endif
