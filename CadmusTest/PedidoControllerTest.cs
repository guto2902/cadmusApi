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
    public class PedidoControllerTest
    {
        private readonly PedidoController _controller;
        private readonly PedidoServiceFake _service;

        public PedidoControllerTest()
        {
            _service = new PedidoServiceFake();
            _controller = new PedidoController(_service);
            
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
            var items = Assert.IsType<List<Pedido>>(okResult.Value);
            Assert.Equal(1, items.Count);
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
            var okResult = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.IsType<Pedido>(okResult.Value);
            Assert.Equal(1, (okResult.Value as Pedido).Numero);
        }

    }
}
