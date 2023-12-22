namespace retroom_last.Models
{
    public class MainViewModel
    {

        public MainViewModel(IList<Restaurant> Restaurants, Person people ,IList<Comment> comments)
        {
            Restaurant = Restaurants;
            Person = people;
            Comments = comments;
        }
        public IList<Restaurant> Restaurant { get; set; }
        public Person Person { get; set; }
        public IList<Comment> Comments { get; set; }

        

    }
}
