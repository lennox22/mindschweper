using System;
using System.Collections.Generic;

namespace ListDemo
{
    public class Product
    {
        private string name;
        private string category;
        private string description;
        private decimal price;

        public Product(string xname, string xcategory, string xdescription, decimal xprice)
        {
            name = xname;
            category = xcategory;
            description = xdescription;
            price = xprice;
        }
        public string xname
        {
            get { return name; }
            set { name = value; }
        }
        public string xcategory
        {
            get { return category; }
            set { category = value; }
        }
        public string xdescription
        {
            get { return description; }
            set { description = value; }
        }
        public decimal xprice
        {
            get { return price; }
            set { price = value; }
        }
        
    }
    public class NameInfo
    {
        public string Firstname;
        public string Lastname;
    }
    public class Names
    {
        private List<NameInfo> pNames = new List<NameInfo>();
        public static Dictionary<string, int> quantities = new Dictionary<string, int>();
        public void addNameInfo(NameInfo item)
        {
            pNames.Add(item);
        }
        public List<NameInfo> getAllNames()
        {
            return pNames;
        }
        public void addQuantity(string item, int num)
        {
            quantities[item] = num;
            Console.WriteLine(quantities[item]);
            if (quantities.ContainsKey(item) == true)
            {
                //found it so add instead of set
                //get current value
                //int current = quantities[item];
                //current += num;
                //save back into dictionary
                quantities[item] += num;
            }
            else
            {
                //didn't find it so just set
                quantities[item] = num;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Names.quantities["red herring"] = 5;
            Console.WriteLine(Names.quantities["red herring"]); 
        }
    }
}
