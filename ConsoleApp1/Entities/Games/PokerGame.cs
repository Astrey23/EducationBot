using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Entities.Games;

public class PokerGame
{
    public Guid Id { get; } = Guid.NewGuid();
    
    private bool _isGameStarted;

    private readonly Random _random = new();

    private readonly HashSet<Card> _cardsInTable = [];

    private readonly HashSet<Player> _players = [];
    
    public IReadOnlyList<Card> CardsInTable => _cardsInTable.ToArray();

    public bool AddPlayer(long userId, string userName)
    {
        if (_isGameStarted) throw new InvalidOperationException("Game is already started");

        return _players.Add(new Player
        {
            UserId = userId,
            Name = userName
        });
    }

    public void Start()
    {
        _isGameStarted = true;

        var cards = new HashSet<Card>();

        var countCards = _players.Count * 2;

        for (var i = 0; i < countCards; i++)
        {
            Card card;
            do
            {
                card = GetRandomCard();
            } while (!cards.Add(card));
        }

        for (var i = 0; i < _players.Count; i++)
        {
            var user = _players.ElementAt(i);
            user.Cards = cards.Skip(i * 2).Take(2).ToArray();
        }
    }

    public void Flop()
    {
        if (!_isGameStarted) throw new InvalidOperationException("Game is not started");
        if (_cardsInTable.Count != 0) throw new InvalidOperationException("Game is already flopped");
        var cards = _players.SelectMany(u => u.Cards!).ToHashSet();
        for (var i = 0; i < 3; i++)
        {
            Card card;
            do
            {
                card = GetRandomCard();
            } while (!cards.Add(card));
        }

        var flopCards = cards.Skip(_players.Count * 2);
        foreach (var flopCard in flopCards)
        {
            _cardsInTable.Add(flopCard);
        }
    }

    public void Turn()
    {
        if (!_isGameStarted) throw new InvalidOperationException("Game is not started");
        if (_cardsInTable.Count != 3) throw new InvalidOperationException("Can't turn");
        var cards = _players.SelectMany(u => u.Cards!).Concat(_cardsInTable).ToHashSet();

        Card card;

        do
        {
            card = GetRandomCard();
        } while (!cards.Add(card));

        var turnCard = cards.Skip(_players.Count * 2 + 3).First();
        _cardsInTable.Add(turnCard);
    }

    public void River()
    {
        if (!_isGameStarted) throw new InvalidOperationException("Game is not started");
        if (_cardsInTable.Count != 4) throw new InvalidOperationException("Can't river");
        var cards = _players.SelectMany(u => u.Cards!).Concat(_cardsInTable).ToHashSet();

        Card card;

        do
        {
            card = GetRandomCard();
        } while (!cards.Add(card));

        var riverCard = cards.Skip(_players.Count * 2 + 4).First();
        _cardsInTable.Add(riverCard);
    }

    public IReadOnlyList<Card> GetCards(long userId)
    {
        if (!_isGameStarted) throw new InvalidOperationException("Game is not started");
        return _players.First(u => u.UserId == userId).Cards!;
    }

    private Card GetRandomCard()
    {
        return new Card((Suit)_random.Next(0, 4), (Rank)_random.Next(2, 14));
    }
}