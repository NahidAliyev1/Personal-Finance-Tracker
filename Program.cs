using Personal_Finance_Tracker.Models;
using Personal_Finance_Tracker.Services;

namespace Personal_Finance_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoryService categoryService = new CategoryService();
            TransactionService transactionService = new TransactionService();
            ReportService reportService = new ReportService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("   ŞƏXSİ BÜDCƏ VƏ XƏRC İZLƏYİCİSİ (Console)   ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Yeni Kateqoriya Əlavə Et");
                Console.WriteLine("2. Kateqoriyaları Göstər");
                Console.WriteLine("3. Yeni Əməliyyat Əlavə Et (Gəlir / Xərc)");
                Console.WriteLine("4. Bütün Əməliyyatları Göstər");
                Console.WriteLine("5. Ümumi Balansı Göstər");
                Console.WriteLine("6. Kateqoriya Üzrə Xərc Hesabatı");
                Console.WriteLine("7. Ən Böyük Xərci Göstər");
                Console.WriteLine("0. Çıxış");
                Console.WriteLine("===========================================");
                Console.Write("Seçiminizi daxil edin (0-7): ");

                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Write("Kateqoriya adı: ");
                            string catName = Console.ReadLine();
                            Console.WriteLine("Tipi seçin: 1 - Gelir, 2 - Xerc");
                            int typeInput = int.Parse(Console.ReadLine());
                            Typee type = (Typee)typeInput;

                            categoryService.Add(catName, type);
                            Console.WriteLine("\nKateqoriya uğurla əlavə edildi!");
                            break;

                        case "2":
                            Console.WriteLine("\n--- MÖVCUD KATEQORİYALAR ---");
                            var categories = categoryService.GetAllCategories();
                            foreach (var cat in categories)
                            {
                                Console.WriteLine($"ID: {cat.Id} | Ad: {cat.Name} | Tip: {cat.Typee}");
                            }
                            break;

                        case "3":
                            Console.Write("Əməliyyatın adı (Title): ");
                            string title = Console.ReadLine();

                            Console.Write("Məbləğ (Amount): ");
                            double amount = double.Parse(Console.ReadLine());

                            Console.Write("Ətraflı açıqlama (Description): ");
                            string desc = Console.ReadLine();

                            Console.Write("Kateqoriya ID-sini daxil edin: ");
                            int catId = int.Parse(Console.ReadLine());

                            transactionService.AddTransaction(title, amount, desc, catId);
                            Console.WriteLine("\nƏməliyyat uğurla bazaya yazıldı!");
                            break;

                        case "4":
                            Console.WriteLine("\n--- BÜTÜN ƏMƏLİYYATLAR ---");
                            var transactions = transactionService.GetAllTransactions();
                            foreach (var t in transactions)
                            {
                                string catNameStr = t.Category != null ? t.Category.Name : "Kateqoriyasız";
                                Console.WriteLine($"[{t.Date.ToString("dd.MM.yyyy HH:mm")}] ID: {t.Id} | {t.Title} | Məbləğ: {t.Amount} AZN | Kateqoriya: {catNameStr}");
                            }
                            break;

                        case "5":
                            double balance = reportService.GetGeneralBalance();
                            Console.WriteLine($"\nCari Balansınız: {balance} AZN");
                            break;

                        case "6":
                            Console.WriteLine("\n--- KATEQORİYA ÜZRƏ XƏRCLƏR ---");
                            reportService.PrintExpensesByCategory();
                            break;

                        case "7":
                            var topExp = reportService.GetTopExpense();
                            if (topExp != null)
                            {
                                Console.WriteLine($"\nƏn Böyük Xərciniz: {topExp.Title} - {topExp.Amount} AZN (Kateqoriya: {topExp.Category?.Name})");
                            }
                            else
                            {
                                Console.WriteLine("\nHələ heç bir xərc daxil edilməyib.");
                            }
                            break;

                        case "0":
                            Console.WriteLine("Proqramdan çıxılır...");
                            return;

                        default:
                            Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXƏTA: {ex.Message}");
                }

                Console.WriteLine("\nDavam etmək üçün ENTER düyməsini sıxın...");
                Console.ReadLine();
            }
        }
    }
}
