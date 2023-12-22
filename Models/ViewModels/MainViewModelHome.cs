namespace retroom_last.Models
{
    public class MainViewModelHome
    {

        public MainViewModelHome(IList<Restaurant> Restaurants ,IList<Comment> comments)
        {
            Restaurant = Restaurants;
          
            Comments = comments;
        }
        public IList<Restaurant> Restaurant { get; set; }
      
        public IList<Comment> Comments { get; set; }

        

    }
}
