using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evau3P.MVVM.Models;
using Evau3P.Services;

namespace Evau3P.MVVM.ViewModels;

public partial class JokesViewModel : ObservableObject
{
    private readonly APIservice _apiService;
    private readonly DataBaseService _databaseService;
    private Jokes _selectedCharacter;
    private int _characterId;

    public Jokes SelectedCharacter
    {
        get => _selectedCharacter;
        set => SetProperty(ref _selectedCharacter, value);
    }

    public int CharacterId
    {
        get => _characterId;
        set
        {
            SetProperty(ref _characterId, value);
            LoadJokeCommand.NotifyCanExecuteChanged();
        }
    }

    public ObservableCollection<Jokes> Characters { get; }

    public IAsyncRelayCommand LoadJokeCommand { get; }
    public IAsyncRelayCommand SaveJokeCommand { get; }
    public IAsyncRelayCommand DeleteJokeCommand { get; }

    public JokesViewModel(APIservice apiService, DataBaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
        Characters = new ObservableCollection<Jokes>();

        LoadJokeCommand = new AsyncRelayCommand(LoadJokeAsync, CanLoadJoke);
        SaveJokeCommand = new AsyncRelayCommand(SaveJokeAsync);
        DeleteJokeCommand = new AsyncRelayCommand<Jokes>(DeleteJokeAsync);
    }

    private async Task LoadJokeAsync()
    {
        var character = await _apiService.GetSWCharactersAsync(CharacterId);
        if (character != null)
        {
            character.ApiId = CharacterId;
            await _databaseService.SaveSWCharactersAsync(character);
            Characters.Add(character);
        }
    }

    private bool CanLoadJoke()
    {
        return CharacterId > 0;
    }

    private async Task SaveJokeAsync()
    {
        if (SelectedCharacter != null)
        {
            await _databaseService.SaveSWCharactersAsync(SelectedCharacter);
        }
    }

    private async Task DeleteJokeAsync(Jokes character)
    {
        await _databaseService.DeleteSWCharactersAsync(character);
        Characters.Remove(character);
    }
}
