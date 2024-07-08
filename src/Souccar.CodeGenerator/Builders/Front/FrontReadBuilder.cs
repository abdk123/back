using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Souccar.CodeGenerator.Builders.Front
{
    public class FrontReadBuilder
    {
        public static string Generate(Type readType)
        {
            return "Hello".Tag("h1");
        }
    }
}
