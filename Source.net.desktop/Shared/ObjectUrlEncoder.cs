using System.Linq;
using System.Threading.Tasks;

namespace Source.net.desktop.Shared
{
    public class ObjectUrlEncoder
    {
        public string AsUrl(object obj)
        {
            var dict = obj.GetType().GetProperties()
                .ToList()
                .Select(p => $"{p.Name} = {p.GetValue(obj)}")
                .ToArray();

            return string.Join("&", dict);
        }
    }
}
