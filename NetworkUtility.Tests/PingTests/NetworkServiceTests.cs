using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            var networkService = new NetworkService();
            var host = "localhost";
            // Act
            var result = networkService.SendPing(host);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Pinging " + host);
            result.Should().Contain(host, Exactly.Once());
        }
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void NetworkService_PingTime_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            var networkService = new NetworkService();
            // Act
            var result = networkService.PingTime(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BePositive();
            result.Should().BeGreaterOrEqualTo(3);
        }
    } 
}
