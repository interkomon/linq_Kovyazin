using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class People
    {
        public string name;
        public string surname;
        public string otchestvo;
        public int age;
        public double weight;
        public People(string name_,string surname_,string otchestvo_,int age_,double weight_)
        {
            name = name_;
            surname = surname_;
            otchestvo = otchestvo_;
            age = age_;
            weight = weight_;
        }
    }
}
