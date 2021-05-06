using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkleXRLib
{
    // Base class for selector-side selection analysis logic
    public class SelectingPredicate : MonoBehaviour
    {
        public virtual bool Check(GameInteractable objectToCheck, Object additionalData = null)
        {
            return true;
        }
    }
}