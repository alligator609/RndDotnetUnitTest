using System.Net.NetworkInformation;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        public NetworkServiceTests()
        {
            //SUT = System Under Test
            _networkService = new NetworkService();
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange          
            var host = "localhost";
            // Act
            var result = _networkService.SendPing(host);

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

            // Act
            var result = _networkService.PingTime(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BePositive();
            result.Should().BeGreaterOrEqualTo(3);
        }


        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            // Arrange

            // Act
            var result = _networkService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2020));
            result.Should().BeBefore(1.January(2026));
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnObject()
        {
            // Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _networkService.GetPingOptions();

            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);

        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnumerable()
        {
            // Arrange
               var expected = new PingOptions
                {
                    DontFragment = true,
                    Ttl = 1
                };
            // Act
            var result = _networkService.MostRecentPings();

            // Assert
            result.Should().NotBeNull(); // Ensure result is not null
            result.Should().BeAssignableTo<IEnumerable<PingOptions>>(); // Check if result is of type IEnumerable<PingOptions>
            result.Should().ContainEquivalentOf(expected); // Check if result contains an item equivalent to 'expected'
            result.Should().OnlyContain(x => x.DontFragment == true && x.Ttl == 1); // Ensure all items have the expected properties
            result.Should().HaveCount(3); // Ensure there are exactly 3 items in the result

        }
    }
}
