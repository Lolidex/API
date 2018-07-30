using System.Collections.Generic;

namespace API.Objects
{
    class SearchParameters
    {
        public string EyeColor { get; set; }
        public string HairColor { get; set; }

        public bool IsEmpty
        {
            get
            {
                return EyeColor == null && HairColor == null;
            }
        }

        public List<string> ToList()
        {
            var list = new List<string>();

            list.Add(EyeColor);
            list.Add(HairColor);

            return list;
        }
    }
}
