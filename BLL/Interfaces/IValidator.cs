namespace BLL.Interfaces
{
    public interface IValidator<T>
    {
        bool Validate(T t);

        bool DoesRecordExist(T t);
    }
}
