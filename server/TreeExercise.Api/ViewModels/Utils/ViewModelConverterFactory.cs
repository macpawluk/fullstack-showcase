namespace TreeExercise.Api.ViewModels.Utils
{
	public class ViewModelConverterFactory : IViewModelConverterFactory
	{
		public IPersonsViewModelConverter CreatePersonsConverter(int maxDepth)
		{
			return new PersonsViewModelConverter(maxDepth);
		}
	}
}
