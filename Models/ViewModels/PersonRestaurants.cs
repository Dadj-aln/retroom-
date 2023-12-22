namespace retroom_last.Models.ViewModels
{
    public class PersonRestaurants
    {
        public PersonRestaurants(IList<Restaurant> restaurants, Person person)
        {
            Restaurants = restaurants;
            Person = person;
        }

        public IList<Restaurant> Restaurants { get; set; }
        public Person Person { get; set; }
    }
}
