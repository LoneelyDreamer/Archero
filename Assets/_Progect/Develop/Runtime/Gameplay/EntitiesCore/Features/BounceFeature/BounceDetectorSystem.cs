using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.BounceFeature
{
    public class BounceDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private LayerMask _layerToBounceReaction;
        private Buffer<Collider> _contacts;
        private Transform _transform;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private Vector3 _previousPosition;
        private Collider _previousObject;
        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _layerToBounceReaction = entity.LayerToBounceReaction;
            _contacts = entity.ContactColliderBuffer;
            _bounceEvent = entity.BounceEvent;

            _previousPosition = _transform.position;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_contacts.Count > 0)
            {
                List<Collider> bouceContacts = new();

                for (int i = 0; i < _contacts.Count; i++)
                    if (MatchWithBounceLayer(_contacts.Items[i]))
                        bouceContacts.Add(_contacts.Items[i]);

                if (bouceContacts.Any())
                {
                    if (Physics.Raycast(_previousPosition, _transform.forward, out RaycastHit hit, 1000, _layerToBounceReaction))
                    {
                        if(hit.collider != _previousObject && bouceContacts.Contains(hit.collider))
                        {
                            _previousObject = hit.collider;
                            _bounceEvent.Invoke(hit);
                            _previousPosition = _transform.position;
                        }
                    }
                }
                else
                {
                    _previousPosition = _transform.position;
                }
            }
        }

        private bool MatchWithBounceLayer(Collider collider)
        {
            return ((1 <<  collider.gameObject.layer) & _layerToBounceReaction) != 0;
        }
    }
}
