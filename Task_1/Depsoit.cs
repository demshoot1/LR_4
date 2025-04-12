using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1;
public class Deposit
{
    private decimal size;
    public void SetSize(decimal newsize)
    {
        size = newsize;
    }
    public decimal GetSize()
    {
        return size;
    }

    public void IncreaseSize(decimal increment)
    {
        size += increment;
    }
    public void DecreaseSize(decimal decrement)
    {
        if (size - decrement > 0)
        {
            size -= decrement;
        }
        else
        {
            Console.WriteLine("Размер вклада меньше, чем значение, на которое надо уменьшить, размер вклада тепреь состовляет 0");
            size = 0;
        }
    }
}

