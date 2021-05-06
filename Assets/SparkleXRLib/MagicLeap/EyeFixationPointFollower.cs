using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeap;
using UnityEngine.XR.MagicLeap;


#if PLATFORM_LUMIN
namespace SparkleXRLib.MagicLeap
{
    public class EyeFixationPointFollower : MonoBehaviour
    {
        void Start()
        {
            MLEyes.Start();
        }

        void Update()
        {
            transform.position = MLEyes.FixationPoint;
        }
    }
}
#endif