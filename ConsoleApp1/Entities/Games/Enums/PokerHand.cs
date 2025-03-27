using System.ComponentModel;

namespace ConsoleApp1.Entities.Games.Enums;

public enum PokerHand
{
    /// <summary>
    /// Старшая карта: Ни одна из вышеперечисленных комбинаций.
    /// </summary>
    [Description("Старшая карта")]
    HighCard = 1,

    /// <summary>
    /// Одна пара: Две карты одного достоинства.
    /// </summary>
    [Description("Одна пара")]
    Pair = 2,

    /// <summary>
    /// Две пары: Две разные пары карт одного достоинства.
    /// </summary>
    [Description("Две пары")]
    TwoPair = 3,

    /// <summary>
    /// Тройка: Три карты одного достоинства.
    /// </summary>
    [Description("Тройка")]
    ThreeOfAKind = 4,

    /// <summary>
    /// Стрит: Пять последовательных карт разных мастей.
    /// </summary>
    [Description("Стрит")]
    Straight = 5,

    /// <summary>
    /// Флеш: Пять карт одной масти.
    /// </summary>
    [Description("Флеш")]
    Flush = 6,

    /// <summary>
    /// Фулл-хаус: Тройка и пара.
    /// </summary>
    [Description("Фулл-хаус")]
    FullHouse = 7,

    /// <summary>
    /// Каре: Четыре карты одного достоинства.
    /// </summary>
    [Description("Каре")]
    FourOfAKind = 8,

    /// <summary>
    /// Стрит-флеш: Пять последовательных карт одной масти.
    /// </summary>
    [Description("Стрит-флеш")]
    StraightFlush = 9,

    /// <summary>
    /// Роял-флеш: Самая старшая стрит-флеш (Туз, Король, Дама, Валет, Десятка одной масти).
    /// </summary>
    [Description("Роял-флеш")]
    RoyalFlush = 10
}
