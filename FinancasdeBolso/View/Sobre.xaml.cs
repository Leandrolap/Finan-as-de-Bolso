namespace FinancasdeBolso.View;

public partial class Sobre : ContentPage
{
	public Sobre()
	{
		InitializeComponent();
	}

    private void OnTappedImage(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}