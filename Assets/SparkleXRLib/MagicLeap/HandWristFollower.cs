using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

#if PLATFORM_LUMIN

namespace SparkleXRLib.MagicLeap
{
    public class HandWristFollower : MonoBehaviour
    {
        [SerializeField]
        public MLHandTracking.HandType handType;
        MLHandTracking.Hand targetHand;

        void Start()
        {
            MLHandTracking.Start();
            if (handType == MLHandTracking.Right.Type)
                targetHand = MLHandTracking.Right;
            else if (handType == MLHandTracking.Left.Type)
                targetHand = MLHandTracking.Left;
        }

        void Update()
        {
            transform.position = targetHand.Wrist.Center.Position;
        }
    }
}
#endif