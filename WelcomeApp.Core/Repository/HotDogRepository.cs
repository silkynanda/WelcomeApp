using System.Collections.Generic;
using System.Linq;
using WelcomeApp.Core.Models;

namespace WelcomeApp.Core.Repository
{
    public class HotDogRepository
    {
        public HotDogRepository()
        {
        }

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          select hotDog;

            return hotDogs.ToList();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.Id == hotDogId
                                          select hotDog;

            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.Id == hotDogGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.HotDogs;
            }

            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.IsFavorite
                                          select hotDog;

            return hotDogs.ToList();
        }

        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>() {
            new HotDogGroup () {
                Id = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog> () {
                    new HotDog () {
                        Id = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese danish fontina.",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> () { "Regular bun", "Sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog () {
                        Id = 2,
                        Name = "Haute Dog",
                        ShortDescription = "The classy one",
                        Description = "Bacon, a lot of it",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string> () { "Baked bun", "Gourmet Sausage", "Ketchup" },
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog () {
                        Id = 3,
                        Name = "Extra Long",
                        ShortDescription = "For when the regular one isn't enough",
                        Description = "Capicola short loin shoulder strip steak ribeye",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> () { "Extra long bun", "Extra long Sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new HotDogGroup () {
                Id = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog> () {
                    new HotDog (){
                        Id = 4,
                        Name = "Veggie Hot Long",
                        ShortDescription = "American for non-meat-lovers",
                        Description = "Veggie Veggie Veggie!",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 5,
                        Ingredients = new List<string> () { "Veggie Things", "Ketchup" },
                        Price = 15,
                        IsFavorite = false
                    }
                }
            }
        };
    }
}
