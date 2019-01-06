using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TreeExercise.Api.ViewModels;
using TreeExercise.Api.ViewModels.Utils;
using TreeExercise.Models.SelectModels;
using TreeExercise.Services;
using TreeExercise.Services.Enums;


namespace TreeExercise.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPersonsService _personsService;
		private readonly IViewModelConverterFactory _viewModelConverterFactory;

		public PersonsController(
			IPersonsService personsService,
			IViewModelConverterFactory viewModelConverterFactory)
		{
			_personsService = personsService;
			_viewModelConverterFactory = viewModelConverterFactory;
		}

		[Route("get-all")]
		[HttpGet]
		public Task<IList<PersonDetails>> GetAllPersons()
		{
			return _personsService.GetAllPersons();
		}

		[Route("get-person-contacts/{personId}")]
		[HttpGet]
		public async Task<PersonWithContactsViewModel> GetPersonContacts(
			int personId, 
			[Range(1, 4)] int searchRange, 
			SearchRangeType searchRangeType)
		{
			var personWithContacts = await _personsService.GetPersonContacts(personId, searchRange, searchRangeType);

			var converter = _viewModelConverterFactory.CreatePersonsConverter(maxDepth: searchRange);
			var viewModel = converter.ConvertToViewModel(personWithContacts);

			return viewModel;
		}
	}
}
