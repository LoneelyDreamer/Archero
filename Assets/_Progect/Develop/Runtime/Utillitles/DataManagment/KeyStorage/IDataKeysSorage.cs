namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.KeyStorage
{
    public interface IDataKeysSorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }

}
