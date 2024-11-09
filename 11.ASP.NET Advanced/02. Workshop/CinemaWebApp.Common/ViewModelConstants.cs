namespace CinemaWebApp.Common
{
    public static class ViewModelConstants
    {
        public static class Movie
        {
            public const int TitleMaxLength = 100;
            public const string TitleRequiredError = "Movie title is required.";
            public const string TitleMaxLengthError = "Movie title is too long.";

            public const string GenreRequiredError = "Genre is required.";

            public const string ReleaseDateRequiredError = "Release date is required.";

            public const int DirectorMaxLength = 100;
            public const string DirectorMaxLengthError = "Director name is too long.";
            public const string DirectorRequiredError = "Director is required.";

            public const int DurationRangeMin = 1;
            public const int DurationRangeMax = 500;
            public const string DurationRangeError = "Duration for the movie must be between 1 and 500 minutes.";
            public const string DurationRequiredError = "Duration is required.";
        }
        public static class Cinema
        {
            public const int NameMaxLength = 80;
            public const string NameMaxLengthError = "Cinema name is too long.";
            public const string NameRequiredError = "Cinema name is required.";

            public const int LocationMaxLength = 50;
            public const string LocationMaxLengthError = "Location is too long.";
            public const string LocationRequiredError = "Location is required.";
        }
    }
}
