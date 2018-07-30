using RethinkDb.Driver;
using RethinkDb.Driver.Model;
using System.Reflection;

namespace API.Objects
{
    class SearchParameters
    {
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public string BirthPlace { get; set; }

        public bool IsEmpty()
        { 
            return EyeColor == null && HairColor == null && Name == null && Height == 0.0 && BirthPlace == null;
        }

        public MapObject ToReQLHashMap()
        {
            RethinkDB r = RethinkDB.R;
            MapObject hashmap = r.HashMap();

            foreach (PropertyInfo prop in typeof(SearchParameters).GetProperties())
            {
                if (prop.GetValue(this) != null && !prop.GetValue(this).Equals(0.0))
                {
                    hashmap = hashmap.With(prop.Name, prop.GetValue(this));
                }
            }

            return hashmap;
        }
    }
}
