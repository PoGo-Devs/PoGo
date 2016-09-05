namespace PoGo.WindowsUniversal.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdatable<in T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        void Update(T update);
    }
}