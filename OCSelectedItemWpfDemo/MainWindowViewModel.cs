using ObservableCollections;

namespace OCSelectedItemWpfDemo;

public class MainWindowViewModel : BindableBase
{
    private readonly ObservableList<int> _observableList = [];
    public INotifyCollectionChangedSynchronizedView<int> ItemsView1 { get; }
    public INotifyCollectionChangedSynchronizedView<ViewData> ItemsView2 { get; }

    public int SelectedItem1
    {
        get => _selectedItem1;
        set => SetProperty(ref _selectedItem1, value);
    }
    private int _selectedItem1;

    public ViewData? SelectedItem2
    {
        get => _selectedItem2;
        set => SetProperty(ref _selectedItem2, value);
    }
    private ViewData? _selectedItem2;

    public RelayCommand AddCommand { get; }

    public MainWindowViewModel()
    {
        _observableList.Add(1);
        _observableList.Add(2);

        ItemsView1 = _observableList.CreateView(x => x)
            .ToNotifyCollectionChanged(SynchronizationContextCollectionEventDispatcher.Current);

        // When converting type using the CreateView(), changes in selection isn't reflected in View.
        ItemsView2 = _observableList.CreateView(x => new ViewData(x))
            .ToNotifyCollectionChanged(SynchronizationContextCollectionEventDispatcher.Current);

        SelectedItem1 = ItemsView1.ElementAt(0);
        SelectedItem2 = ItemsView2.ElementAt(0);

        AddCommand = new(() => _observableList.Add(Random.Shared.Next(100)));
    }
}

public class ViewData(int value)
{
    public string Value { get; } = $"ViewData - {value}";
    public override string ToString() => Value;
}