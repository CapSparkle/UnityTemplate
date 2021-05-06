﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkleXRLib
{
    public class SpherecastSelector : Selector
    {

        // Director and cast source must be different!
        [SerializeField]
        public Transform director;
        [SerializeField]
        public Transform castSource;

        [SerializeField]
        float _radius;

        public float radius 
        {
            get
            { 
                return _radius; 
            }
            private set
            {
                _radius = value;
            }
        }

        [SerializeField]
        float _maxDistance;

        public float maxDistance
        {
            get
            {
                return _maxDistance;
            }
            private set
            {
                _maxDistance = value;
            }
        }
        [SerializeField]
        LayerMask ignoredLayers;


        public delegate void hitInfoNotification(RaycastHit[] hits);
        public hitInfoNotification spherecastHitInfo;
        


        void GetInteractables()
        {
            selectedInteractables.Clear();

            if(castSource.position != director.position)
            {
                RaycastHit[] hits = Physics.SphereCastAll(castSource.position, _radius, director.position - castSource.position, _maxDistance);
                int i = 0;
                foreach (RaycastHit hit in hits)
                {
                    print("Sphere Caster (uid:" + m_selectorUID + ") " + "hit №" + i + " - " + hit.transform.name);
                    GameInteractable handler;
                    if (handler = hit.transform.GetComponent<GameInteractable>())
                        AddInteractable(handler);
                    i++;
                }
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(castSource.position, _radius, ignoredLayers);
                int i = 0;
                foreach (Collider collider in colliders)
                {
                    print("Sphere Caster (uid:" + m_selectorUID + ") " + "hit №" + i + " - " + collider.transform.name);
                    GameInteractable handler = null;
                    if (handler = collider.transform.GetComponent<GameInteractable>())
                        AddInteractable(handler);

                    i++;
                }
            }


        }

        #region -sorting-
        public override List<GameInteractable> SortInteractables(List<GameInteractable> interactablesToSort = null)
        {
            if (interactablesToSort != null)
            {
                interactablesToSort.Sort(Compare);
                return interactablesToSort;
            }
            interactablesToSort.Sort(Compare);
            return interactablesToSort;
        }

        public int Compare(GameInteractable x, GameInteractable y)
        {
            float xRange = Math.Abs((x.transform.position - castSource.position).magnitude);
            float yRange = Math.Abs((y.transform.position - castSource.position).magnitude);
            if (xRange > yRange)
                return 1;
            else if (xRange < yRange)
                return -1;
            else
                return 0;
        }

        #endregion -sorting-

        void Update()
        {
            GetInteractables();
        }
    }
}