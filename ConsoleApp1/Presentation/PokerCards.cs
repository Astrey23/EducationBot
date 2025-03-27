using ConsoleApp1.Entities.Games;
using ConsoleApp1.Entities.Games.Enums;

namespace ConsoleApp1.Presentation;

public static class PokerCards
{
    public static readonly Dictionary<Card, string> CardsStickers = new()
    {
        { new Card(Suit.Hearts, Rank.Two), "CAACAgUAAxkBAAIBE2finCFSS7NnPFjIvniiIpzSDQ3qAALAAQACuLTAVShA-tzLnnP1NgQ" },
        { new Card(Suit.Hearts, Rank.Three), "CAACAgUAAxkBAAIBFWfinC17O5ymLZMGrRSrcpwk7vltAAKSAQACLcXBVTKPs6KUqQRCNgQ" },
        { new Card(Suit.Hearts, Rank.Four), "CAACAgUAAxkBAAIBF2finDa4SywBYq8_s7ZHxIj_ATsAA50BAALSHsBV5Z5z-HpyjhE2BA" },
        { new Card(Suit.Hearts, Rank.Five), "CAACAgUAAxkBAAIBGWfinEKctfgeMsEqNwABcRSuT8rf7QAC9wADiiHBVSWGu92DeH5pNgQ" },
        { new Card(Suit.Hearts, Rank.Six), "CAACAgUAAxkBAAIBG2finEdSGNr5z-iBraJe-rQVt5zpAAK5AQACLt_BVSd0XI6_Ut65NgQ" },
        { new Card(Suit.Hearts, Rank.Seven), "CAACAgUAAxkBAAIBHWfinFArRzq7geTSA_QkjqxecpFZAAJkAQAC1X3BVVzY34i5GXHQNgQ" },
        { new Card(Suit.Hearts, Rank.Eight), "CAACAgUAAxkBAAIBH2finFYP7_SzfJ3y6W6sy-wdtWkdAAJYAQACT7rBVQLR8GSac1m8NgQ" },
        { new Card(Suit.Hearts, Rank.Nine), "CAACAgUAAxkBAAIBIWfinF703Y2tZ4z43I_3Bp4KDQl1AAKkAQACgPLBVdxX6QUuXgajNgQ" },
        { new Card(Suit.Hearts, Rank.Ten), "CAACAgUAAxkBAAIBI2finGMONOGKzRjcV5i62wtUYzC7AAIRAQACQVvAVW6I30V-k1lZNgQ" },
        { new Card(Suit.Hearts, Rank.Jack), "CAACAgUAAxkBAAIBJWfinGn6lDRDTcYxkukK2yQpAYpuAAJPAQAC5nrBVV4dVDLw60NkNgQ" },
        { new Card(Suit.Hearts, Rank.Queen), "CAACAgUAAxkBAAIBJ2finG7Sol_1O9kz92_i44YAAdm_3QACVwEAAhgewFWcKPy_MO0FAjYE" },
        { new Card(Suit.Hearts, Rank.King), "CAACAgUAAxkBAAIBKWfinHPvbexEEU4syFiCffr1NqSIAAIZAQACFFPBVaNQEXjukDoRNgQ" },
        { new Card(Suit.Hearts, Rank.Ace), "CAACAgUAAxkBAAIBK2finHhYSVbC7JyElxOIk2bKwRMTAAKKAQAC9IjAVUr-jhrgPNBoNgQ" },
        
        { new Card(Suit.Diamonds, Rank.Two), "CAACAgUAAxkBAAIBLWfinIziDFHgbKMr2B6Gm0O9syssAAIGAQACai_IVZjp2Phz3h9iNgQ" },
        { new Card(Suit.Diamonds, Rank.Three), "CAACAgUAAxkBAAIBL2finJGI6ALsCMBsLV6St4Es9LWuAAKVAQAC6-XBVQAB-jYcWMD4eTYE" },
        { new Card(Suit.Diamonds, Rank.Four), "CAACAgUAAxkBAAIBMWfinKpYjQwR97MTbn2tioLxOt2BAALBAQACoM3AVaIN1OrMorb2NgQ" },
        { new Card(Suit.Diamonds, Rank.Five), "CAACAgUAAxkBAAIBM2finK97FqDzbIo_kcTp77WODCYBAAKZAQACkSDBVQNa19QuSpruNgQ" },
        { new Card(Suit.Diamonds, Rank.Six), "CAACAgUAAxkBAAIBNWfinLTic_yqH4mjfMCv5VLxZLIuAAIXAQAC-3_BVaDHqcqlfNBiNgQ" },
        { new Card(Suit.Diamonds, Rank.Seven), "CAACAgUAAxkBAAIBCWfimsGWjbMmqGsekwT_UaM1R5urAAKNAQACslbAVbRxwx7tNKAqNgQ" },
        { new Card(Suit.Diamonds, Rank.Eight), "CAACAgUAAxkBAAIBOWfinLwcPSK1NJpAMZ3Tu3hBlBZ2AAJdAQACa0TAVaOlxOpPw2PhNgQ" },
        { new Card(Suit.Diamonds, Rank.Nine), "CAACAgUAAxkBAAIBO2finMFEWH2uIHdkzDKHH6offz9YAAI1AQAC5CTBVVWD4WjnG1dCNgQ" },
        { new Card(Suit.Diamonds, Rank.Ten), "CAACAgUAAxkBAAIBPWfinMXCKT7DstTnXKY6rkSUFa9uAAJSAQACGVvAVXyb4ntYTbUqNgQ" },
        { new Card(Suit.Diamonds, Rank.Jack), "CAACAgUAAxkBAAIBP2finMtqe5dx8RWpn2P8CqVwsYXMAAJNAQACccLJVbe0Fo3lXpcQNgQ" },
        { new Card(Suit.Diamonds, Rank.Queen), "CAACAgUAAxkBAAIBQWfinM9LI8AITGP0NUncikbSWtgPAAK4AQACuGXAVVe2VOIIRacNNgQ" },
        { new Card(Suit.Diamonds, Rank.King), "CAACAgUAAxkBAAIBQ2finNTCzj8_iZEL-rGUdhsF0meoAAJ-AQACuf7BVYGHtHzfhYbPNgQ" },
        { new Card(Suit.Diamonds, Rank.Ace), "CAACAgUAAxkBAAIBRWfinNkbN3PB4Jp0H9AH2apgb-hiAAJMAQACuWvBVQKMX0_5YOpsNgQ" },
        
        { new Card(Suit.Spades, Rank.Two), "CAACAgUAAxkBAAIBEWfimwLn-SGfCtoT92wmTDj2tF4XAAJ2AQACz7HAVapEM6-mHpt6NgQ" },
        { new Card(Suit.Spades, Rank.Three), "CAACAgUAAxkBAAIBTWfinOsMxIemXvzJvRr67ALhOjjkAAKIAQACWvXAVcPOLFA9YHRrNgQ" },
        { new Card(Suit.Spades, Rank.Four), "CAACAgUAAxkBAAIBS2finOrD8qAkY2HCiLHMM-5n-DbfAAL1AAOQP8BVMJeM2xSBYVw2BA" },
        { new Card(Suit.Spades, Rank.Five), "CAACAgUAAxkBAAIBT2finPT0Tj_Edw1ZhPpBO-_Y5HobAAK2AQACeXnBVS3oExTVXitBNgQ" },
        { new Card(Suit.Spades, Rank.Six), "CAACAgUAAxkBAAIBUWfinPm00YQ5RdUCO9x72lsb8pE-AALCAQACExnIVRUBCTbD0hSjNgQ" },
        { new Card(Suit.Spades, Rank.Seven), "CAACAgUAAxkBAAIBU2finP8TsFnZSnaAjJfLzx44_65hAAJfAQACVyrBVZgoDoBoN4s0NgQ" },
        { new Card(Suit.Spades, Rank.Eight), "CAACAgUAAxkBAAIBVWfinQTi9f6DA3EDy_w9-xir51LJAALmAQACkYDAVVhfNhGDmXaFNgQ" },
        { new Card(Suit.Spades, Rank.Nine), "CAACAgUAAxkBAAIBV2finQqT8MG_R33QnOTDZsSSU4XlAAJMAQACVNvBVQ6J5yTZpE90NgQ" },
        { new Card(Suit.Spades, Rank.Ten), "CAACAgUAAxkBAAIBWWfinQ80vGY49U9nwIK2oN556PWiAAJ-AQACMRxxVqvHRoEJTsHcNgQ" },
        { new Card(Suit.Spades, Rank.Jack), "CAACAgUAAxkBAAIBW2finRZX4ikgJ3cLpcJNKd0pw07KAAKBAQACDXPAVWos8ldKhjasNgQ" },
        { new Card(Suit.Spades, Rank.Queen), "CAACAgUAAxkBAAIBXWfinRyPXpXOtmou8U0RaT3TdyB4AAKpAgACiZPAVVigAmH3ZQUuNgQ" },
        { new Card(Suit.Spades, Rank.King), "CAACAgUAAxkBAAIBX2finSHGpBLfgE6O7PtJD1t4yQklAAKlAQACa2nAVeCjtI0sCyCoNgQ" },
        { new Card(Suit.Spades, Rank.Ace), "CAACAgUAAxkBAAIBD2fimwFL0Sb7fYhzCF79hdbL1CfbAAJ7AQACgJnAVeD42v7uFlqgNgQ" },
        
        { new Card(Suit.Clubs, Rank.Two), "CAACAgUAAxkBAAIBY2finT6TM1IKjm5Kfb6hakWArRVhAALuAAPMP8BVQ2XrbSl_zlU2BA" },
        { new Card(Suit.Clubs, Rank.Three), "CAACAgUAAxkBAAIBZWfinUJ75BaVutsebb0DLbg8Pg3dAALEAAONdclVKAXVzhJ9BFU2BA" },
        { new Card(Suit.Clubs, Rank.Four), "CAACAgUAAxkBAAIBZ2finUbFogj4tuPj3m77w95a1pPNAALVAAN2fcFV2yMwkJGvAz42BA" },
        { new Card(Suit.Clubs, Rank.Five), "CAACAgUAAxkBAAIBa2finVjm28-1_t1rs4MBAmhI1TUWAAJBAQACrK7AVQou9l-diivQNgQ" },
        { new Card(Suit.Clubs, Rank.Six), "CAACAgUAAxkBAAIBaWfinUz4QXXZs81CsoGeegGwkQ2BAAIsAQAC9K7BVdNlqc0bHvACNgQ" },
        { new Card(Suit.Clubs, Rank.Seven), "CAACAgUAAxkBAAIBbWfinWDuyG_EIq0bozR1JvQ50VvFAALpAAOanMBV-p6MpO8DT3E2BA" },
        { new Card(Suit.Clubs, Rank.Eight), "CAACAgUAAxkBAAIBb2finWa5YjLBGuv51LtkoqBmKP13AAJlAQACayfAVfMNtS82uVIgNgQ" },
        { new Card(Suit.Clubs, Rank.Nine), "CAACAgUAAxkBAAIBcWfinWpf9lRHyz4Gl_BJKxTjkYomAAIfAQACg9PBVfRdtJ1hlPBrNgQ" },
        { new Card(Suit.Clubs, Rank.Ten), "CAACAgUAAxkBAAIBc2finW_RAVpQbDxp0O9RK7MQAod2AAJYAQACkIzAVWqaKiO5FRmdNgQ" },
        { new Card(Suit.Clubs, Rank.Jack), "CAACAgUAAxkBAAIBdWfinXN2vYC7CJkjOJxj4oePNnK-AAJKAQACtVLBVacmKs428ayMNgQ" },
        { new Card(Suit.Clubs, Rank.Queen), "CAACAgUAAxkBAAIBd2finXdV2LieuFsOv9bKllWXTKwuAAJjAQAC1lTBVUH0muvr30MGNgQ" },
        { new Card(Suit.Clubs, Rank.King), "CAACAgUAAxkBAAIBeWfinXy_Wf2nJjLpZVIl1wbsXlo7AAJqAQACtXXAVSxTAh2tsevONgQ" },
        { new Card(Suit.Clubs, Rank.Ace), "CAACAgUAAxkBAAIBe2finX_sU7ag2xD4t0ESHfKR-Vl2AAJWAQACTsrAVR2w87xsPLfNNgQ" },
    };
}