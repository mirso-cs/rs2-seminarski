using System.Linq;
using System.Threading.Tasks;

namespace Source.net.desktop.Shared
{
    public class ClassUrlEncoder
    {
        public string EncodeAsUrl(object obj)
        {
            var dict = obj.GetType().GetProperties()
                .ToList()
                .Select(p => $"{p.Name} = {p.GetValue(obj)}")
                .ToArray();

            return string.Join("&", dict);
        }
    }
}
