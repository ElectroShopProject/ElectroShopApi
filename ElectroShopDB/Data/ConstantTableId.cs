namespace ElectroShopDB
{
    public static class ConstantTableId
    {
        public static class ProductCategory
        {
            public static int Ebook = 1;
            public static int Storage = 2;
            public static int Others = 3;
        }

        public static class PaymentStatus
        {
            public static string Success = "f0f0c53a-029a-460b-a364-3179aa7a0b09";
            public static string Failure = "4a8a2d3e-5953-4be3-8117-598d3bb66e5c";
            public static string Progress = "1f16f0aa-4b30-4af1-8255-34885b200036";
        }

        public static class PaymentOption
        {
            public static string CreditCard = "809e3eb8-afe5-41f1-bc78-956b9c06e8c3";
            public static string BankTransfer = "5de5b37d-43e5-48c0-9048-a7eb2e2c7f4b";
            public static string PayPal = "bc7abde2-7c46-42b7-811e-6a3335eadf27";
            public static string Cash = "94338185-58cc-47a5-b2a9-6a1c5dfbce7a";
        }

        public static class TaxRate
        {
            public static string Tax5 = "fe92aa85-ae2a-4260-a550-dc11538e9e31";
            public static string Tax8 = "1fa465f9-16d8-43b2-88a2-8213d38ac214";
            public static string Tax23 = "ebb479d6-d683-47ce-bd31-7999f2a290ef";
        }

        public static class Manufacturer
        {
            public static string Feder = "26c1a403-05a3-4c33-9dd4-41152fb51f8d";
            public static string Itera = "947f9287-5217-4689-bf2b-0323af4434ab";
            public static string Konemi = "9b590ce7-1679-4dbb-bb07-12604bfc4e2b";
        }

        public static class Product
        {
            public static string GameDevelopmentBook = "86f43ace-25c5-45e4-9e1f-b578d396bcc6";
            public static string LargeHardDrive = "cf947456-04e1-4906-ae62-3d31cefcf93d";
            public static string Smartphone = "3a31aae0-da59-4505-b20f-e02cc1e58d19";
            public static string ScreenCleaner = "6eda4234-8b32-4dc8-a271-9f27408cd72d";
            public static string InternetCamera = "dc34401a-f099-464b-af91-d934aab27e53";
        }
    }
}
