using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodLINQ
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

            var profiles = arrProfile
                                .Where(profile => profile.Height < 175)
                                .OrderBy(profile => profile.Height)
                                .Select(profile =>
                                        new
                                        {
                                            Name = profile.Name,
                                            InchHeight = profile.Height * 0.393
                                        });

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}



