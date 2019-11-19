namespace Source.net.services.Mappers
{
    public interface Mapper<TEntity, TView, TCreate, TUpdate>
    {
        TEntity To(TCreate dto);
        TEntity To(TView view);
        TEntity To(TUpdate dto, TEntity entity);
        TView From(TEntity entity);
    }
}
