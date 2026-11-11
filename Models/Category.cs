using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Models;
public class Category:BaseModel
{
    public string Name { get; set; }
    public Typee Typee { get; set; }
    public Category(string name,Typee typee)
    {
        Name = name;
        Typee = typee;
    }

}
