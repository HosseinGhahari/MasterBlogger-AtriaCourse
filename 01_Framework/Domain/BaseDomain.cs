using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Domain
{
    public class BaseDomain<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseDomain()
        {
            CreationDate = DateTime.Now;
        }
    } 
}
