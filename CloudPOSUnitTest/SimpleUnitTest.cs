using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPOSUnitTest
{
    public class SimpleUnitTest
    {
        [Fact]
        public void AddTestResult()
        {
            //1)Arrange 
            var simpleCalculator=new SimpleCalculator();
            int expectedResult = 3;
            int n1=1,n2=2;
            //2)Action
           var result= simpleCalculator.Add(n1, n2);//3
            //3)Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
