namespace CQRSDemoLibrary.DataAccess
{
    public interface IDataAccess<out T>
    {
        public IEnumerable<T> List(int? pageStart, int? pageSize);
        public IEnumerable<T> GetLatestProducts(int? pageStart, int? pageSize);
    }
}