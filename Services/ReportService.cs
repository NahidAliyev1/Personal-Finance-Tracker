using Microsoft.EntityFrameworkCore;
using Personal_Finance_Tracker.Contexts;
using Personal_Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Services;
public class ReportService
{
    private PersonalFinanceTrackerDbContext _context;

    public ReportService()
    {
        _context = new PersonalFinanceTrackerDbContext();
    }

    public double GetGeneralBalance()
    {
        double totalIncome = _context.Transactions
            .Where(t => t.Category.Typee == Typee.Gelir)
            .Sum(t => t.Amount);

        double totalExpense = _context.Transactions
            .Where(t => t.Category.Typee == Typee.Xerc)
            .Sum(t => t.Amount);

        return totalIncome - totalExpense;
    }
    public void PrintExpensesByCategory()
    {
        
        var groupedExpenses = _context.Transactions
            .Where(t => t.Category.Typee == Typee.Xerc)
            .GroupBy(t => t.Category.Name)
            .Select(group => new
            {
                CategoryName = group.Key,         
                TotalAmount = group.Sum(t => t.Amount) 
            })
            .ToList();

        foreach (var item in groupedExpenses)
        {
            Console.WriteLine($"Kateqoriya: {item.CategoryName} - Ümumi Xərc: {item.TotalAmount} AZN");
        }
    }


    public Transactionn? GetTopExpense()
    {
       
        return _context.Transactions
            .Include(t => t.Category)
            .Where(t => t.Category.Typee == Typee.Xerc)
            .OrderByDescending(t => t.Amount)
            .FirstOrDefault();
    }

}
