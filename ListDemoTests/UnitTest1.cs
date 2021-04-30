using System;
using Xunit;
using ListDemo;
using System.Collections.Generic;

namespace ListDemoTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            NameInfo name = new ListDemo.NameInfo();
            name.Firstname = "Sally";
            name.Lastname = "Smith";

            Names names = new Names();
            names.addNameInfo(name);

            int count = names.getAllNames().Count;

            Assert.Equal(1, count);
        }
        //[Fact]
        //public void TestQuantities()
        //{
            //Names names = new Names();
            //names.addQuantity("apple", 10);
           // names.addQuantity("apple", 6);

            //int amount = names.quantities["apple"];
            //Assert.Equal(16, amount);
        //}
    }
}
