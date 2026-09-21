namespace Assets._Progect.Develop.Runtime.Utillitles
{
    public class Buffer<T>
    {
        public T[] Items;
        public int Count;

        public Buffer(int intialSize)
        {
            Items = new T[intialSize];
            Count = 0;
        }
    }
}
