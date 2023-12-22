namespace retroom_last.Models
{
    public class RestaurantCommentViewModel
    {
        public RestaurantCommentViewModel(Restaurant restaurantt, IList<Comment> comments)
        {
            restaurant = restaurantt;
            Comments = comments;
        }

        public Restaurant restaurant { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
