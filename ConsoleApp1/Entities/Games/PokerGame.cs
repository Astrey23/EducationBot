using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Entities.Games;

public class PokerGame
{
    public Guid Id { get; } = Guid.NewGuid();

    private bool _isGameStarted;

    private readonly Random _random = new();

    private readonly HashSet<Card> _cardsInTable = [];

    private readonly HashSet<Player> _players = [];

    public IReadOnlyCollection<Card> CardsInTable => _cardsInTable;

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

        Card cardOne = new Card(Suit.Spades, Rank.Ace);
        Card cardTwo = new Card(Suit.Diamonds, Rank.Ace);
        Card cardThree = new Card(Suit.Spades, Rank.Two);

        cards.Add(cardOne);
        cards.Add(cardTwo);
        cards.Add(cardThree);
        // for (var i = 0; i < 3; i++)
        // {
        //     Card card;
        //     do
        //     {
        //         card = GetRandomCard();
        //     } while (!cards.Add(card));
        // }

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

    public IReadOnlyList<Card> GetCardsOnTable(long userId)
    {
        if (!_isGameStarted) throw new InvalidOperationException("Game is not started");
        return _cardsInTable.ToArray();
    }

    private IReadOnlyDictionary<long, Combination?> CheckCombinations()
    {
        var combinations = new Dictionary<long, Combination?>();

        foreach (var player in _players)
        {
            var cardsInGame = player.Cards!
                .Concat(_cardsInTable)
                .OrderByDescending(c => c.Rank)
                .ToArray();

            var groupedRankCards = cardsInGame
                .GroupBy(card => card.Rank)
                .ToArray();

            var groupedSuitCards = cardsInGame
                .GroupBy(card => card.Suit)
                .ToArray();

            //todo: проверяем комбинации по порядку...

            // предположим что эта комбинация получена из нужного метода, удалить
            var combination = new Combination { Hand = PokerHand.HighCard, Rank = Rank.Two };
            combinations[player.UserId] = combination;
        }

        return combinations;
    }

    private static Combination? IsPair(IGrouping<Rank, Card>[] cards)
    {
        var rank = cards.FirstOrDefault(g => g.Count() == 2)?.Key;
        if (rank == null) return null;
        
        return new Combination
        {
            Hand = PokerHand.Pair, 
            Rank = rank.Value
        };
    }

    private static Combination? IsTwoPair(IGrouping<Rank, Card>[] cards)
    {
        var rankFirstPair = cards.FirstOrDefault(g => g.Count() == 2)?.Key;
        if (rankFirstPair == null) return null;
        
        var rankSecondPair = cards.FirstOrDefault(g => g.Count() == 2 && g.Key != rankFirstPair)?.Key;
        if (rankSecondPair == null) return null;
        
        return new Combination
        {
            Hand = PokerHand.TwoPair,
            Rank = rankFirstPair.Value,
            SecondaryRank = rankSecondPair.Value
        };
    }

    private static Combination? IsThreeOfAKind(IGrouping<Rank, Card>[] cards)
    {
        var rank = cards.FirstOrDefault(g => g.Count() == 3)?.Key;
        if (rank == null) return null;
        
        return new Combination
        {
            Hand = PokerHand.ThreeOfAKind,
            Rank = rank.Value
        };
    }

    private static Combination? IsStraight()
    {
        return null;
    }

    private static Combination? IsFlush(IGrouping<Suit, Card>[] cards)
    {
        var suitGrouping = cards.FirstOrDefault(g => g.Count() >= 5);
        if (suitGrouping == null) return null;
        
        var rank = suitGrouping.OrderByDescending(c => c.Rank).First().Rank;
    }

    private static Combination? IsFullHouse(IGrouping<Rank, Card>[] cards)
    {
        var rankThreeOfAKind = cards.FirstOrDefault(g => g.Count() == 3)?.Key;
        if (rankThreeOfAKind == null) return null;
        
        var rankPair = cards.FirstOrDefault(g => g.Count() == 2 && g.Key != rankThreeOfAKind)?.Key;
        if (rankPair == null) return null;

        return new Combination
        {
            Hand = PokerHand.FullHouse, 
            Rank = rankThreeOfAKind.Value, 
            SecondaryRank = rankPair.Value
        };
    }

    private static Combination? IsFourOfAKind(IGrouping<Rank, Card>[] cards)
    {
        var rank = cards.FirstOrDefault(g => g.Count() == 4)?.Key;
        if (rank == null) return null;
        
        return new Combination
        {
            Hand = PokerHand.FourOfAKind,
            Rank = rank.Value
        };
    }


    private Card GetRandomCard()
    {
        return new Card((Suit)_random.Next(0, 4), (Rank)_random.Next(2, 14));
    }
}