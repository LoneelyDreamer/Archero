namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders
{
    public interface IDataReader<TData> where TData : ISaveData
    {
        void ReadFrom(TData data);
    }

}
