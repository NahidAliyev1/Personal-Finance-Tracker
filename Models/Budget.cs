using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Models;
public class Budget:BaseModel
{
    public int CategoryId { get; set; }
    public double LimitAmount { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}
