using System.Collections.Generic;

namespace WelcomeApp.Core.Models
{
    public class HotDogGroup
    {
        public HotDogGroup()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public List<HotDog> HotDogs { get; set; }
    }
}
