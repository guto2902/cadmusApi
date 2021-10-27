using cadmus.Controllers;
using cadmus.Models;
using CadmusTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CadmusTest
{
    public class ClienteControllerTest
    {
        private readonly ClienteController _controller;
        private readonly ClienteServiceFake _service;

        public ClienteControllerTest()
        {
            
            _service = new ClienteServiceFake();

            _controller = new ClienteController(_service);

        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Cliente>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }


        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {

            // Act
            var okResult = _controller.Get(3);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {

            // Act
            var okResult = _controller.Get(3) as OkObjectResult;

            // Assert
            Assert.IsType<Cliente>(okResult.Value);
            Assert.Equal(3, (okResult.Value as Cliente).Id);
        }
    }
}
