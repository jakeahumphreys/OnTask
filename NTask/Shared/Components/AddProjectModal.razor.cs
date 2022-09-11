using System.ComponentModel.DataAnnotations;
using NTask.Data.Services.Models.DTO;

namespace NTask.Shared.Components;

public partial class AddProjectModal
{
    private string _modalClass = "";
    private string _modalDisplay = "";
    private bool _showBackdrop = false;

    private AddProjectFormModel _formModel = new AddProjectFormModel();

    public void Show()
    {
        _modalDisplay = "block;";
        _modalClass = "Show";
        _showBackdrop = true;
        StateHasChanged();
    }
    
    public void Hide()
    {
        _modalDisplay = "none;";
        _modalClass = "";
        _showBackdrop = false;
        StateHasChanged();
    }

    void FormSubmit()
    {
        Console.WriteLine("Form Submitted");
    }
}

public class AddProjectFormModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
}
