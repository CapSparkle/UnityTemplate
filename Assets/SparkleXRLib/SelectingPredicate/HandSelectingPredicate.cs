using SparkleXRLib.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SparkleXRLib
{
    
    public class HandSelectingPredicate : SelectingPredicate
    {
        public override bool Check(GameInteractable objectToCheck, Object additionalData = null)
        {
            if (objectToCheck.GetComponentInChildren<Takeable>() != null)
                return true;
            else
                return false;
        }
    }
}

