namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.KeyStorage
{
    public interface IDataKeySorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }

}
