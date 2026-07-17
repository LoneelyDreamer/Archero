using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        private readonly ISaveLoadServise _saveLoadServise;

        private TData _data;    
        protected DataProvider(ISaveLoadServise saveLoadServise)
        {
            _saveLoadServise = saveLoadServise;
        }

        public IEnumerator Load()
        {
            yield return _saveLoadServise.Load<TData>(loadedData => _data = loadedData);
        }

        public IEnumerator Save()
        {
            yield return _saveLoadServise.Save(_data);
        }

        public IEnumerator Exists(Action<bool> onExistsResult)
        {
            yield return _saveLoadServise.Exists<TData>(result => onExistsResult?.Invoke(result));
        }

        public void Reset()
        {
            _data = GetOriginData();
        }

        protected abstract TData GetOriginData();
    }
}
