using System.Reflection;

namespace El_Cliente.Api.Helpers
{
    public static class ConvertsExtensions
    {
        public static TEntity ConvertToEntity<TDto, TEntity>(TDto dto) where TEntity : new()
        {
            TEntity entity = new TEntity();
            Type dtoType = typeof(TDto);
            Type entityType = typeof(TEntity);

            foreach (PropertyInfo dtoProp in dtoType.GetProperties())
            {
                PropertyInfo entityProp = entityType.GetProperty(dtoProp.Name);
                if (entityProp != null && entityProp.CanWrite)
                {
                    entityProp.SetValue(entity, dtoProp.GetValue(dto));
                }
            }

            return entity;
        }
    }
}
