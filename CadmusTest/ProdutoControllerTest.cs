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

    
    public class ProdutoControllerTest
    {
        private readonly ProdutoController _controller;
        private readonly ProdutoServiceFake _service;

        public ProdutoControllerTest()
        {
            _service = new ProdutoServiceFake();
            _controller = new ProdutoController(_service);
            
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
            var items = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(8, items.Count);
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
            Assert.IsType<Produto>(okResult.Value);
            Assert.Equal(3, (okResult.Value as Produto).Id);
        }


       
    }
}
