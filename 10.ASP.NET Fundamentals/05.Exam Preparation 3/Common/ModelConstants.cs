﻿namespace Homies.Common
{
    public static class ModelConstants
    {
        public static class Event
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 150;

            public const string DateTimeFormat = "yyyy-MM-dd H:mm";

            public const string NameRequiredError = "Event Name Is Required!";
            public const string DescriptionRequiredError = "Event Description Is Required!";
            public const string TypeRequiredError = "Event Type Is Required!";
        }
        public static class Type
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 15;
        }
    }
}
