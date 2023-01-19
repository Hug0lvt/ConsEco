using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BanqueInscrit : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Name { get; set; }
        public int Id { get; set; }

        [JsonConstructor]
        public BanqueInscrit(int id, string nomBanque)
        {
            Id = id;
            Name = nomBanque;
        }

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return Name + " " + Id;
        }
    }
}
