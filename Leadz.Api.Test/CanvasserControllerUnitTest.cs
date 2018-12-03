using Leadz.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Leadz.Api.Controllers;
using Leadz.Api.Models;

namespace Leadz.Api.Test
{
	public class CanvasserControllerUnitTest
	{
		[Theory]
		[InlineData(1)]
		public async void GetCanvasser_canvasseridexpected(int value)
		{
			//arrange


			var canvasser = Task.FromResult(Getcanvasser());
			
			Mock<ICanvasserRepo> mock = new Mock<ICanvasserRepo>();

			mock.Setup(c => c.GetById(value)).Returns(canvasser);

			var controller = new CanvassersController(mock.Object);

			//act

			var actionResult = await controller.GetCanvasser(value);


			//assert
			var okObjectResult = actionResult as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var model = okObjectResult.Value as Canvasser;
			Assert.NotNull(model);

			Assert.Equal(value, model.Id);
		}
		[Theory]
		[InlineData(5)]
		public async void GetCanvasser_canvasserisNullexpected(int value)
		{
			//arrange


			var canvasser = Task.FromResult(Getcanvasser());

			Mock<ICanvasserRepo> mock = new Mock<ICanvasserRepo>();

			mock.Setup(c => c.GetById(1)).Returns(canvasser);

			var controller = new CanvassersController(mock.Object);

			//act

			var actionResult = await controller.GetCanvasser(value);
			

			//assert
			var okObjectResult = actionResult as OkObjectResult;
			
			Assert.Null(okObjectResult);
			
		}
				[Fact]
		public async void GetAllCanvassers_ListExpected()
		{
			var canvasser = Task.FromResult(Getcanvassers());

			Mock<ICanvasserRepo> mock = new Mock<ICanvasserRepo>();

			mock.Setup(c => c.GetAll()).Returns(canvasser);

			var controller = new CanvassersController(mock.Object);

			var actionResult = await controller.GetCanvasser();

			Assert.Equal(2, actionResult.Count());
		}





		private Canvasser Getcanvasser()
		{
			
			return new Canvasser
			               {
											 Id = 1,
				               Name    = "Kevin Wood",
				               Address = "33 canteststreet, testtown,",
				               PhoneNo = 07765432198,
				               TeamId  = 1,
				               Role    = "Leader",
			               };
		}


		private IEnumerable<Canvasser> Getcanvassers()
		{
			var canvassers = new List<Canvasser>();
			canvassers.Add(new Canvasser
			               {
				               Name    = "Kevin Wood",
				               Address = "33 canteststreet, testtown,",
				               PhoneNo = 07765432198,
				               TeamId  = 1,
				               Role    = "Leader",
			               });

			canvassers.Add(new Canvasser
			               {
				               Name    = "Tom Smith",
				               Address = "12 canteststreet, testtown,",
				               PhoneNo = 077123456789,
				               TeamId  = 1,
				               Role    = "Canvasser",
			               });


			return canvassers;
		}
		}
}