using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BanqueInscrit
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        [JsonConstructor]
        public BanqueInscrit(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
