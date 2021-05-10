using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
