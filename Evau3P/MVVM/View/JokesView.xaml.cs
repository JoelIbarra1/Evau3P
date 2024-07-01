using Evau3P.MVVM.ViewModels;

namespace Evau3P.MVVM.View;

public partial class JokesView : ContentPage
{
    private readonly JokesViewModel _viewModel;
    public JokesView(JokesViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}