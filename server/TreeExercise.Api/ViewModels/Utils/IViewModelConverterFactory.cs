namespace TreeExercise.Api.ViewModels.Utils
{
	public interface IViewModelConverterFactory
	{
		IPersonsViewModelConverter CreatePersonsConverter(int maxDepth);
	}
}
