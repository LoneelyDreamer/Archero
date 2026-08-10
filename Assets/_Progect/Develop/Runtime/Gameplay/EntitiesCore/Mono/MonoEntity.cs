using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntity : MonoBehaviour
    {
        private Entity _linkedEntity;
        private CollidersRegestryService _collidersRegestryService;

        public Entity LinkedEntity => _linkedEntity;

        public void Initialize(CollidersRegestryService collidersRegestryService)
        {
            _collidersRegestryService = collidersRegestryService;
        }
        public void Link(Entity entity)
        {
            _linkedEntity = entity;

            MonoEntityRegistrator[] registrators = GetComponentsInChildren<MonoEntityRegistrator>();

            if (registrators != null)
                foreach (MonoEntityRegistrator registrator in registrators)
                    registrator.Register(entity);

            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegestryService.Regester(collider, entity);


        }

        public void Cleanup(Entity entity)
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegestryService.Unregester(collider);

            _linkedEntity = null;
        }
    }

}
