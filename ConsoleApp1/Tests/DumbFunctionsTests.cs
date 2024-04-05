using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    public class DumbFunctionsTests
    {
        public static void ReturnsPikachu_WhenGiven1_ReturnsPikachu()
        {
            // Arrange => go get your things, class variables ,  
            int num = 1;

            // Act  => Call the function you wanna test
            string result = DumbFunctions.ReturnsPikachu(num);

            // Assert => Check if this is the actual result you want 
            if (result == "Pikachu!")
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
        }
    }
}
