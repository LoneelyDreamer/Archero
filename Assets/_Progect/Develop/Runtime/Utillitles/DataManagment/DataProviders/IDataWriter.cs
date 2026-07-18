namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders
{
    public interface IDataWriter<TData> where TData : ISaveData
    {
        void WriteTo(TData data);
    }

}
