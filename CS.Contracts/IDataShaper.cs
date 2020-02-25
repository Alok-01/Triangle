using CS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CS.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);

        ShapedEntity ShapeData(T entity, string fieldsString);
    }
}
