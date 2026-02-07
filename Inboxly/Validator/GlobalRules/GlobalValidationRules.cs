namespace Inboxly.Validator.GlobalRules
{
    public class GlobalValidationRules
    {
        public static string NotEmpty(string name)
            => $"{name} alanı boş bırakılamaz.";

        public static string MinLenght(int lenght, string name)
            => $"{name} alanı için minimum {lenght} uzunluğunda değer girilmelidir.";

        public static string MaxLenght(int lenght, string name)
            => $"{name} alanı için maksimum {lenght} uzunluğunda değer girilmelidir.";

        public static string OnlyLettersWithSingleSpace(string name)
            => $"{name} alanı sadece harflerden oluşmalıdır.";

        public static string OnlyNumbers(string name)
            => $"{name} alanı sadece rakamlardan oluşmalıdır.";

        public static string PhoneTR(string name)
            => $"{name} alanı doğru formatta değil.Lütfen kontrol ediniz !!!";

        public static string Email(string name)
            => $"{name} alanı doğru formatta değil.Lütfen kontrol ediniz !!!";


        public const string ForOnlyLettersWithSingleSpace = @"^\p{L}+(?: \p{L}+)*$";

        public const string ForOnlyNumbers = @"^[0-9]+$";

        public const string ForPhoneTR = @"^(?:\+90|0)?5[0-9]{9}$";

        public const string ForEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    }
}
