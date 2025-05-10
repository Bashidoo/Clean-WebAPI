using Application_Layer.Dtos;
using Application_Layer.Interfaces.CustomerInterface;

using AutoMapper;
using Domain_Layer.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Application_Layer.Queries.CustomerQueries.CreateACustomer;

namespace Tests.QueryTests
{
    public class Tests
    {
        [Test]
        public async Task Handle_WithValidCustomer_ReturnsSuccessMessageWithName()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CreateCustomerCommandHandler>>();

            var customerDto = new CustomerDto
            {
                Name = "Jane Doe",
                Email = "jane@example.com"
            };

            var mappedCustomer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                
            };

            mockMapper.Setup(m => m.Map<Customer>(customerDto)).Returns(mappedCustomer);
            mockRepo
    .Setup(r => r.AddCustomerAsync(It.IsAny<Customer>()))
    .ReturnsAsync(mappedCustomer);

            var handler = new CreateCustomerCommandHandler(
                mockRepo.Object,
                mockMapper.Object,
                mockLogger.Object);

            var request = new CreateCustomerCommandQuery(customerDto);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            StringAssert.Contains("Successfully created customer: Jane Doe", result);
        }
    }
}
