namespace MovePigMove.Core.Entities
{
    public interface IDomainEntity<out TDataModel>
    {
        TDataModel GetInnerModel();
    }
}