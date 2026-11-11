using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Models;
public class Transactionn:BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public  double Amount { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Transactionn(string title,string description,double amount,int categoryId)
    {
        Date = DateTime.Now;
        Title = title;
        Description = description;
        Amount = amount;
        CategoryId = categoryId;
    }
}
