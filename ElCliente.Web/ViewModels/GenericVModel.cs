using El_Cliente.Shared.DTOs;

namespace ElCliente.Web.ViewModels
{
    public class GenericVModel : GenericDTO
    {
        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object o)
        {
            var other = o as GenericVModel;
            return other?.Id == Id;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}