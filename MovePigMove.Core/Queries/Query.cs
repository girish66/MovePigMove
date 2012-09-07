namespace MovePigMove.Core.Queries
{
    public abstract class Query<TEntity> 
    {
        public abstract bool IsMatch(TEntity entity);
    }
}