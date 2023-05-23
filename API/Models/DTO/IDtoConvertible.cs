namespace API.Models.DTO
{
    /// <summary>
    /// Defines a contract for models that can be converted to DTO's and vice-versa;
    /// </summary>
    public interface IDtoConvertible<T>
    {
        public T Map();
    }
    
}