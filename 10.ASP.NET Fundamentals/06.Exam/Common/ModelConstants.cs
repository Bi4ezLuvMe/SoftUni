namespace DeskMarket.Common
{
    public static class ModelConstants
    {
        public static class Product
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 60;
            public const string NameRequiredError = "Product Name Is Required!";
            public const string NameMinLengthError = "Product Name Must Be At Least 2 Characters Long!";
            public const string NameMaxLengthError = "Product Name Must Not Be More Than 60 Characters Long!";

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
            public const string DescriptionRequiredError = "Product Description Is Required";
            public const string DescriptionMinLengthError = "Product Description Must Be At Least 10 Characters Long!";
            public const string DescriptionMaxLengthError = "Product Description Must Not Be More Than 250 Characters Long!";

            public const int PriceMinRange = 1;
            public const int PriceMaxRange = 3000;
            public const string PriceRequiredError = "Product Price Is Required!";
            public const string PriceMinRangeError = "Product Price Must Be More Than 1$!";
            public const string PriceMaxRangeError = "Product Price Must Not Be More Than 3000$!";

            public const string DateTimeFormat = "dd-MM-yyyy";

            public const string ProductCategoryError = "The Product Category Is Required!";
        }
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }
    }
}
