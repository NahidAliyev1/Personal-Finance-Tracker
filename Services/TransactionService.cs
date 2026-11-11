using Microsoft.EntityFrameworkCore;
using Personal_Finance_Tracker.Contexts;
using Personal_Finance_Tracker.Exceptions;
using Personal_Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Personal_Finance_Tracker.Services;

public class TransactionService
{
    private readonly PersonalFinanceTrackerDbContext _context;
    public TransactionService()
    {
        _context = new PersonalFinanceTrackerDbContext();
    }



    public void AddTransaction(string title,double amount,string description,int categoryId)
    {
        if (string.IsNullOrWhiteSpace(title) || amount <= 0)
        {
            throw new CustomException("Bos ola bilmez");
        }
        var category = _context.Categories.Find(categoryId);
        if (category is   null)
        {
            throw new CustomException("bu idli tapilmadi");
        }
        else
        {
            Transactionn transaction = new Transactionn(title, description, amount, categoryId);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }


       

    }
    public List<Transactionn> GetAllTransactions()
    {
        return _context.Transactions
                    .Include(t => t.Category)
                    .OrderByDescending(t => t.Date)
                    .ToList();
    }
    public void DeleteTransaction(int id)
    {
        var transaction = _context.Transactions.Find(id);
        if (transaction is not null)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }
        else
        {
            throw new CustomException($"{id} ID-li əməliyyat tapılmadı!");
        }
    }
}
