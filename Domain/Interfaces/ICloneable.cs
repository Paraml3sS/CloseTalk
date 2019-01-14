namespace Domain.Interfaces
{
    public interface ICloneable<T>
    {
        T DeepClone();
    }
}
