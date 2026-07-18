using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        private readonly ISaveLoadServise _saveLoadServise;

        private List<IDataWriter<TData>> _writers = new();
        private List<IDataReader<TData>> _readers = new();


        private TData _data;    
        protected DataProvider(ISaveLoadServise saveLoadServise)
        {
            _saveLoadServise = saveLoadServise;
        }

        public void RegisterWriter(IDataWriter<TData> writer)
        {
            if (_writers.Contains(writer))
                throw new ArgumentException(nameof(writer));

            _writers.Add(writer);
        }
        public void RegisterReader(IDataReader<TData> reader)
        {
            if (_readers.Contains(reader))
                throw new ArgumentException(nameof(reader));

            _readers.Add(reader);
        }

        public IEnumerator Load()
        {
            yield return _saveLoadServise.Load<TData>(loadedData => _data = loadedData);

            SendDataToReaders();
        }

        public IEnumerator Save()
        {
            UpdateDataFromWriters();

            yield return _saveLoadServise.Save(_data);
        }

        public IEnumerator Exists(Action<bool> onExistsResult)
        {
            yield return _saveLoadServise.Exists<TData>(result => onExistsResult?.Invoke(result));
        }

        public void Reset()
        {
            _data = GetOriginData();

            SendDataToReaders();
        }

        protected abstract TData GetOriginData();

        private void SendDataToReaders()
        {
            foreach (IDataReader<TData> reader in _readers)
                reader.ReadFrom(_data);
        }

        private void UpdateDataFromWriters()
        {
            foreach(IDataWriter<TData> writer in _writers)
                writer.WriteTo(_data);
        }
    }

}
