using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Core
{
    public class Program
    {
        public static void CreateExampleTest()
        {
            List<TestInfo> testInfos = new();

            Test t = new Test(
                "Тест самоопределения тревоги Д. Шихана",
                "Определите, насколько Вас беспокоили в течение последней недели указанные ниже симптомы. Отметьте номер Вашего ответа на бланке ответов.",
                new() { Test.DEFAULT_TAG },
                new()
                {
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Затруднение на вдохе, нехватка воздуха или учащенное дыхание\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Ощущение удушья или комка в горле\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Сердце скачет, колотится, готово выскочить из груди\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Загрудинная боль, неприятное чувство сдавления в груди\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Профузная потливость (пот градом)\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Слабость, приступы дурноты, головокружения\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "\"Ватные\", \"не свои\" ноги\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Ощущение неустойчивости или потери равновесия\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Тошнота или неприятные ощущения в животе\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Ощущение того, что все окружающее становится странным, нереальным, туманным или отстраненнымОщущение того, что все окружающее становится странным, нереальным, туманным или отстраненным\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Ощущение, что все плывет, \"нахожусь вне тела\"\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Покалывание или онемение в разных частях тела\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Приливы жара или озноба\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Дрожь (тремор)\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Страх смерти или того, что сейчас может произойти что-то ужасное\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Страх сойти с ума или потери самообладания\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Внезапные приступы тревоги, сопровождающиеся тремя или более из вышеперечисленных признаков, возникающие непосредственно перед и при попадании в ситуацию, которая, по Вашему опыту, может вызвать приступ\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Внезапные неожиданные приступы тревоги, сопровождающиеся тремя или более из выше перечисленных признаков, возникающие по незначительным поводам или без повода (т.е., когда Вы НЕ находитесь в ситуации, которая, по Вашему опыту, может вызвать приступ)\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Внезапные неожиданные приступы, сопровождающиеся только одним или двумя из вышеперечисленных признаков, возникающие по незначительным поводам или без повода (т.е., когда Вы НЕ находитесь в ситуации, которая, по Вашему опыту, может вызвать приступ)\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Периоды тревоги, нарастающей по мере того, как Вы готовитесь сделать что-то, что, по Вашему опыту, может вызвать тревогу, причем более сильную, чем ту, что в таких случаях испытывает большинство людей\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Избегание пугающих вас ситуаций\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Состояние зависимости от других людей\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Напряженность и неспособность расслабиться\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Тревога, \"нервозность\", беспокойство\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Приступы повышенной чувствительности к звуку, свету и прикосновению\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Приступы поноса\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Чрезмерное беспокойство о собственном здоровье\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Ощущение усталости, слабости и повышенной истощаемости\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Головные боли или боли в шее\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Трудности засыпания\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Просыпания среди ночи или беспокойный сон\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Неожиданные периоды депрессии, возникающие по незначительным поводам или без повода\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Перепады настроения и эмоций, которые в основном зависят от того, что происходит вокруг Вас\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Повторяющиеся и неотступные представления, мысли, импульсы или образы, которые Вам кажутся тягостными, противными, бессмысленными или отталкивающими\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Questions = new() { "Повторение одного и того же действия как ритуала, например, повторные перепроверки, перемывание и пересчет при отсутствии в этом действии необходимости\n" },
                        Variants = new() { "Нисколько - 0", "Немного - 1", "Умеренно - 2", "Сильно - 3", "Крайне сильно - 4" },
                        VariantsTag = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    }
                },
                new()
                {
                    {
                        Test.DEFAULT_TAG,
                        new Dictionary<string, int>()
                        {
                            { "тяжелое тревожное расстройство", 80 },
                            { "клинически выраженная тревога", 30 },
                            { "отсутствие клинически выраженной тревоги", 0 }
                        }
                    }
                }
                );
            Test t2 = new Test(
                "Тест на репрезентативные системы",
                "Пеpед вами  четыpе высказывания.  Они не закончены.  Под каждым из" +
                "них имеются четыpе окончания. " +
                "Обозначьте окончание, котоpое  больше всего подходит вам - цифpой 4; " +
                "котоpое немного меньше подходит вам - цифpой 3 и т.д. " +
                "Поставьте 1 пеpед окончанием, котоpое меньше всего подходит вам. " +
                "Пpоделайте это под каждым из четыpех высказываний. " +
                "Высказывания под номеpом 5 закончены,  но они pазные, и поэтомy их надо также оценить",
                new() { Test.DEFAULT_TAG, "K", "V", "A", "D" },
                new()
                {
                    new QuestionRateAnswer()
                    {
                        Text = "Я пpинимаю важные pешения, основанные на:",
                        Questions = new()
                        {
                            "хоpошо пpовеpенных чyвствах",
                            "том, что звyчит лyчше",
                            "том, что выглядит для меня лyчше всего",
                            "точном, стаpательном изyчении вопpоса"
                        },
                        Variants = new()
                        {
                            "Не подходит",
                            "Скорее не подходит",
                            "Скорее подходит",
                            "Подходит"
                        },
                        VariantsTag = new() { "K", "A", "V", "D" },
                        MaxRate = 4,
                        MinRate = 1,
                        UnicValues = true
                    },
                    new QuestionRateAnswer()
                    {
                        Text = "Во вpемя споpа на меня чаще всего влияет:",
                        Questions = new()
                        {
                            "тон голоса дpyгого человека",
                            "могy ли я или нет ясно видеть точкy зpения дpyгого человека",
                            "логика аpгyментов дpyгого человека",
                            "чyвствyю я или нет, что я в контакте с дpyгими настоящими чyвствами этого человека"
                        },
                        Variants = new()
                        {
                            "Не подходит",
                            "Скорее не подходит",
                            "Скорее подходит",
                            "Подходит"
                        },
                        VariantsTag = new() { "A", "V", "D", "K" },
                        MaxRate = 4,
                        MinRate = 1,
                        UnicValues = true
                    },
                    new QuestionRateAnswer()
                    {
                        Text = "Я могy очень пpосто понять свое настpоение с помощью:",
                        Questions = new()
                        {
                            "того, как я одеваюсь",
                            "чyвств, котоpые я pазделяю",
                            "слов, котоpые я выбиpаю",
                            "своего тона голоса"
                        },
                        Variants = new()
                        {
                            "Не подходит",
                            "Скорее не подходит",
                            "Скорее подходит",
                            "Подходит"
                        },
                        VariantsTag = new() { "V", "K", "D", "A" },
                        MaxRate = 4,
                        MinRate = 1,
                        UnicValues = true
                    },
                    new QuestionRateAnswer()
                    {
                        Text = "Для меня пpосто:",
                        Questions = new()
                        {
                            "подобpать идеальнyю гpомкость и звyчание на стеpео системе",
                            "выбpать наиболее интеллектyальные места,  по интеpесyющемy меня пpедметy",
                            "выбpать чpезвычайно yдобнyю мебель",
                            "выбpать комбинации (сочетания) насыщенных цветов"
                        },
                        Variants = new()
                        {
                            "Не подходит",
                            "Скорее не подходит",
                            "Скорее подходит",
                            "Подходит"
                        },
                        VariantsTag = new() { "A", "D", "K", "V" },
                        MaxRate = 4,
                        MinRate = 1,
                        UnicValues = true
                    },
                    new QuestionRateAnswer()
                    {
                        Text = "",
                        Questions = new()
                        {
                            "Я бyквально настpаиваюсь на звyки в моем окpyжении",
                            "Я хоpошо yмею осмысливать новые факты и данные",
                            "Я  очень чyвствителен к томy,  как пpедметы одежды воздействyют на меня",
                            "Я сильно pеагиpyю на цвета и на то, как выглядит комната"
                        },
                        Variants = new()
                        {
                            "Не подходит",
                            "Скорее не подходит",
                            "Скорее подходит",
                            "Подходит"
                        },
                        VariantsTag = new() { "A", "D", "K", "V" },
                        MaxRate = 4,
                        MinRate = 1,
                        UnicValues = true
                    },
                },
                new()
                {
                    { "K", new() { { "K isn`t ok", 3 }, { "K is ok", 1 }, { "K is perfect", 0 } } },
                    { "V", new() { { "V isn`t ok", 3 }, { "V is ok", 1 }, { "V is perfect", 0 } } },
                    { "A", new() { { "A isn`t ok", 3 }, { "A is ok", 1 }, { "A is perfect", 0 } } },
                    { "D", new() { { "D isn`t ok", 3 }, { "D is ok", 1 }, { "D is perfect", 0 } } },
                }
                );

            t.GUID = Guid.Parse("00000000-0000-0000-0000-000000000001");
            t2.GUID = Guid.Parse("00000000-0000-0000-0000-000000000002");

            testInfos.Add(t.GetTestInfo());
            testInfos.Add(t2.GetTestInfo());
            JsonWork.SaveTest(t);
            JsonWork.SaveTest(t2);
            JsonWork.SaveTestInfoList(testInfos);
        }
        public static void CreateExamplePatients()
        {

            var rnd = new Random();
            List<PatientInfo> ptlist = new List<PatientInfo>();
            List<Patient> ptInfos = new List<Patient>();

            ptInfos.Add(new Patient("Al", "Van", "Hell", new DateTime(1999, 2, 1), "муж"));
            ptInfos.Add(new Patient("Den", "0_o", "Morti", new DateTime(1995, 5, 11), "муж"));
            ptInfos.Add(new Patient("Ig", "Rock", "uwu", new DateTime(2005, 3, 23), "муж"));


            TestResult testResult = new("test1", "ok");
            testResult.TestGUID = Guid.Parse("00000000-0000-0000-0000-000000000001");
            testResult.results = new List<TagResult>{ new( "def", 100) };
            testResult.completeTime = DateTime.Now - new TimeSpan(1, 10, 1, 0);
            ptInfos[0].TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.Parse("00000000-0000-0000-0000-000000000002");
            testResult.results = new List<TagResult> { new("def", 50 ), new("K", 50 )};
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            ptInfos[0].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[0]);

            testResult = new("test1", "no");
            testResult.TestGUID = Guid.Parse("00000000-0000-0000-0000-000000000001");
            testResult.results = new List<TagResult> { new("def", 130 ) };
            testResult.completeTime = DateTime.Now - new TimeSpan(10, 1, 0);
            ptInfos[1].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[1]);

            testResult = new("test1", "mb");
            testResult.TestGUID = Guid.Parse("00000000-0000-0000-0000-000000000001");
            testResult.results = new List<TagResult> { new("def", 50) };
            testResult.completeTime = DateTime.Now - new TimeSpan(25 ,10, 1, 0);
            ptInfos[2].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[2]);


            ptlist.Add(ptInfos[0].GetPatientCut());
            ptlist.Add(ptInfos[1].GetPatientCut());
            ptlist.Add(ptInfos[2].GetPatientCut());
            JsonWork.SavePatientsInfoList(ptlist);
        }
        public static Patient CreateExamplePatient()
        {
            Patient pt = new Patient("Al", "Van", "Hell", new DateTime(1999, 2, 1), "муж");

            TestResult testResult = new("test1", "ok");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 4) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            return pt;
        }
    }
}
