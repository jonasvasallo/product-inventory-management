public class HeaderDataService
{
    public event Action? OnChange;

    private string _title = "Default Title";
    public string Title
    {
        get => _title;
        set
        {
            if (_title == value) return;
            _title = value;
            OnChange?.Invoke();
        }
    }
}