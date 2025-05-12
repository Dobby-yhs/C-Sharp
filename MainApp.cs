using System;
using System.Linq;

namespace GroupBy
{ 
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile() {Name = "AAA", Height = 186 },
                new Profile() {Name = "BBB", Height = 158 },
                new Profile() {Name = "CCC", Height = 172 },
                new Profile() {Name = "DDD", Height = 178 },
                new Profile() {Name = "EEE", Height = 171 }
            };

            var listprofiles = from profile in arrProfile
                               orderby profile.Height
                               group profile by profile.Height < 175 into g
                               select new { GroupKey = g.Key, Profiles = g };

            foreach(var Group in listprofiles)
            {
                Console.WriteLine($"- 175cm 미만? : {Group.GroupKey}");

                foreach(var Profile in Group.Profiles)
                {
                    Console.WriteLine($">>> {Profile.Name}, {Profile.Height}");
                }
            }
        }
    }
}



