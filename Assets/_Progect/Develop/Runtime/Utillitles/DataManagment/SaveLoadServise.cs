using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataRepository;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.KeyStorage;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.Serializers;
using System;
using System.Collections;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment
{
    public class SaveLoadServise : ISaveLoadServise
    {
        private readonly IDataSerializer _serializer;
        private readonly IDataKeysSorage _keysStorage;
        private readonly IDataRepository _repository;

        public SaveLoadServise(
            IDataSerializer serializer,
            IDataKeysSorage keysStorage,
            IDataRepository repository)
        {
            _serializer = serializer;
            _keysStorage = keysStorage;
            _repository = repository;
        }

        public IEnumerator Exists<TData>(Action<bool> onExistsResult) where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            yield return _repository.Exists(key, result => onExistsResult?.Invoke(result));
        }

        public IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            string serializedData = "";

            yield return _repository.Read(key, result => serializedData = result);

            TData data = _serializer.Deserialize<TData>(serializedData);

            onLoad?.Invoke(data);
        }

        public IEnumerator Remove<TData>() where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            yield return _repository.Remove(key);
        }

        public IEnumerator Save<TData>(TData data) where TData : ISaveData
        {
            string serializedData = _serializer.Serialize(data);

            string key = _keysStorage.GetKeyFor<TData>();

            yield return _repository.Write(key, serializedData);
        }
    }
}
