using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TrainingPlansWA.Areas.Identity.Data;
using TrainingPlansWA.Models;
namespace TrainingPlansWA.Controllers {
    public class LegsPlansController : Controller {
        /*public IActionResult Index() {
            return View();
        }*/
        PlansContext db;
        UserManager<UserModel> _userManager;
        public LegsPlansController(PlansContext context, UserManager<UserModel> userManager) {
            _userManager = userManager;
            db = context;
               if (!db.Plans.Any()) {

                Plan plan1 = new Plan {
                    CrossDBId = "h1",
                    Category = "Hands",
                    Exercises = {
                    new Exercise { Name = "Разминка плечевого сустава" },
                    new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу 25-20-15-10 с увеличением веса" },
                    new Exercise { Name = "Жим штанги стоя + Разводка гантель стоя 8-10-12-15 с уменьшением веса" },
                    new Exercise { Name = "Тяга штанги к поясу обратным хватом 25-20-15-12-10-8-8" },
                    new Exercise { Name = "Трицепс с гантелью стоя 30-25-20-15-10" },
                    new Exercise { Name = "Трицепс с кривой штангой лёжа 15-12-10-8-15" },
                    new Exercise { Name = "ПВП (пресс, вис, планка)" }
                    }
                };
                Plan plan2 = new Plan {
                    CrossDBId = "h2",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа на горизонтальной скамье 15-12-10-8" },
            new Exercise { Name = "Жим штанги лёжа на наклонной скамье-//-//-" },
            new Exercise { Name = "Пуловер с гантелью лёжа поперёк скамьи -//-//-" },
            new Exercise { Name = "Бицепс с гантелями сидя одновременно + Бицепс с пустым грифом 15+15 3 серии" },
            new Exercise { Name = "Молот стоя поочередно 15 по 5 раз; 10+5; 15+5; 25" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan3 = new Plan {
                    CrossDBId = "h3",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка" },
            new Exercise { Name = "Разводка гантель стоя 10+10 3 серии" },
            new Exercise { Name = "Жим гантель стоя 8-8-10-10" },
            new Exercise { Name = "Протяжка с кривой штангой широким хватом 8-8-10-10" },
            new Exercise { Name = "Тяга Т-грифа параллельным хватом 8-8-10-12-15" },
            new Exercise { Name = "Тяга гантели в наклоне 8-10-12-15" },
            new Exercise { Name = "Молот стоя одновременно 25-20-15-10" },
            new Exercise { Name = "ПВП" },
        }
                };
                Plan plan4 = new Plan {
                    CrossDBId = "h4",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 8-10-10-12-15" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 3х15" },
            new Exercise { Name = "Отжимание от брусьев с резиной 3хмакс" },
            new Exercise { Name = "Жим штанги лёжа узким хватом 8-10-12-15" },
            new Exercise { Name = "Трицепс-блок одной рукой 3х15 1’ отдыха" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan5 = new Plan {
                    CrossDBId = "h5",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия 2х25" },
            new Exercise { Name = "Отведение руки в тренажере на заднюю дельту 3х15" },
            new Exercise { Name = "Жим штанги стоя 15-12-10-8-8 с увеличением веса" },
            new Exercise { Name = "Протяжка с кривой штангой средним хватом-//-//-" },
            new Exercise { Name = "Тяга Т-грифа параллельный хват 15-12-10-8" },
            new Exercise { Name = "Трицепс с гантелью стоя + Трицепс от лежака 25-20-15-10" },
            new Exercise { Name = "Вис 1’, пресс на коврике 3х25 1’ отдыха, планка 1’" },
        }
                };

                Plan plan6 = new Plan {
                    CrossDBId = "h6",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа 25(гриф)-15-12-10-8-6" },
            new Exercise { Name = "Отжимание от брусьев 5х10" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Бицепс с кривой штангой 3х3 по 7" },
            new Exercise { Name = "Сгибание Зотмана 4х15" },
            new Exercise { Name = "Кисти штанга сидя 3хмакс" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan7 = new Plan {
                    CrossDBId = "h7",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Жим штанги лёжа 15-12-10-8" },
            new Exercise { Name = "Жим гантель стоя-//-//-" },
            new Exercise { Name = "Тяга штанги к поясу -//-//-" },
            new Exercise { Name = "Присед с блином 10 кг 5х20" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно 20-18-15 + Трицепс с гантелью стоя 15" },
            new Exercise { Name = "Пресс + Гиперэкстензия блин 5 кг 25+25 3 серии" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan8 = new Plan {
                    CrossDBId = "h8",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х25" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда ладони наружу + Жим гантель стоя одновременно 15; 12; 10; 8" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 15-12-10-8" },
            new Exercise { Name = "Бицепс с прямой штангой + Трицепс с гантелью стоя 15-12-10-8 + 25-20-15-10" },
            new Exercise { Name = "Пресс на наклонной скамье с поворотами 5х18; планка 1’" },
        }
                };

                Plan plan9 = new Plan {
                    CrossDBId = "h9",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу 25-20-15-15" },
            new Exercise { Name = "Жим гантель сидя в упоре + Разводка гантель сидя 10+10;12+12;15+15;20+20" },
            new Exercise { Name = "Тяга штанги к поясу с увеличением веса 20-18-15-12-10-8" },
            new Exercise { Name = "Сгибание Зотмана + Трицепс с гантелями лёжа 15+25-20-15-10" },
            new Exercise { Name = "Пресс, планка, вис (на своё усмотрение)" },
        }
                };

                Plan plan10 = new Plan {
                    CrossDBId = "h10",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Жим штанги лёжа широкий хват наклонная скамья 15-12-10-8" },
            new Exercise { Name = "Разводка стоя вес максимум 5х10 1’ отдыха" },
            new Exercise { Name = "Тяга Т-грифа параллельный хват 3х15" },
            new Exercise { Name = "Шаги-фермера с гантелями вес максимум 4х8" },
            new Exercise { Name = "Бицепс-кривуха 15-12-10-8 + Трицепс с гантелями лёжа 15" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan11 = new Plan {
                    CrossDBId = "h11",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 3х20" },
            new Exercise { Name = "Жим штанги лёжа + Отжимание от лежака широким хватом 10+15 3 серии" },
            new Exercise { Name = "Тяга вертикальная к груди с увеличением веса средним хватом сверху 18-15-12-10-8-8" },
            new Exercise { Name = "Шраги с гантелями 8 кг 4х25" },
            new Exercise { Name = "Молот стоя попеременно с высоким весом + Трицепс-блок 10+15 3 серии" },
            new Exercise { Name = "Вис 1’, пресс на наклонной скамье с поворотами 4х18, планка 1’" },
        }
                };

                Plan plan12 = new Plan {
                    CrossDBId = "h12",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу 15;12;10;8" },
            new Exercise { Name = "Жим штанги стоя (лучше брать не стандартный гриф из угла) 15-12-10-8" },
            new Exercise { Name = "Разводка гантель стоя одной рукой в наклоне и упоре (либо за шведскую стенку, либо за гриф Смитта, можно брать вес гантель выше среднего) 15-12-10-8" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно + Молот стоя раздельно 25-20-15 + 15-12-8" },
            new Exercise { Name = "Пресс 2х25, планка 1’" },
        }
                };

                Plan plan13 = new Plan {
                    CrossDBId = "h13",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Перекладина параллельный хват 3хмакс" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху широкий 15-12-10-8" },
            new Exercise { Name = "Тяга гантели в наклоне 20-18-15-12-10 1’ отдыха" },
            new Exercise { Name = "Трицепс от лежака + Трицепс-блок в тренажере 25;20;15" },
            new Exercise { Name = "Трицепс с гантелями стоя в наклоне одновременно 2х25 (3-4 кг не больше)" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan14 = new Plan {
                    CrossDBId = "h14",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2(3) кг" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу 25-20-15-10" },
            new Exercise { Name = "Жим штанги стоя за голову 15-12-10-8-8" },
            new Exercise { Name = "Разводка гантель стоя 10+15 1’ отдыха (понижение веса гантель на 1 кг) 3 серии" },
            new Exercise { Name = "Тяга Т-грифа 15-12-10-8-15" },
            new Exercise { Name = "Тяга 2-ух гантель в наклоне (не бери большой вес гантель, больше прожимай лопатки) 15-20-25" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan15 = new Plan {
                    CrossDBId = "h15",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Бабочка с увеличением веса 20-15-12-10-8" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 20(разминка)-8-10-12-15" },
            new Exercise { Name = "Разводка лёжа (гири) 12(14) кг 3х15" },
            new Exercise { Name = "Бицепс с прямым грифом 13,5 кг 25-20-15" },
            new Exercise { Name = "Бицепс с гантелями стоя попеременно 15-12-10-8" },
            new Exercise { Name = "Фр.жим стоя с гантелью 25-20-15-12-10-8 1’ отдыха" },
            new Exercise { Name = "Трицепс от лежака 2х25" },
            new Exercise { Name = "Кисти, ПВП" },
        }
                };

                Plan plan16 = new Plan {
                    CrossDBId = "h16",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель стоя 25-20-15-10" },
            new Exercise { Name = "Жим штанги стоя с увеличением веса 15-12-10-8-8" },
            new Exercise { Name = "Тяга штанги к поясу обратным хватом 3х15" },
            new Exercise { Name = "Тяга 2-ух гантель в наклоне 6-5-5 кг х 15-20-25" },
            new Exercise { Name = "Разводка стоя в наклоне блины по 2,5 кг 4х20" },
            new Exercise { Name = "Пресс на перекладине 4х15; планка 1’" },
        }
                };

                Plan plan17 = new Plan {
                    CrossDBId = "h17",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа + Отжимание от лежака широким хватом 15-12-10-8-6" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 3х15" },
            new Exercise { Name = "Жим Свенда 2 блина по 2,5 кг 4х15" },
            new Exercise { Name = "Бицепс с прямым грифом с расширителями + Трицепс с гантелью стоя 15-12-10-8 + 25-20-15-10" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan18 = new Plan {
                    CrossDBId = "h18",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч 15-15-15" },
            new Exercise { Name = "Жим гантель стоя (стартуем с 4-5 кг)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой (широкий, средний, узкий хваты)" },
            new Exercise { Name = "15 + 15-12-8" },
            new Exercise { Name = "Разводка стоя полная амплитуда ладони наружу 15-12-10-8" },
            new Exercise { Name = "Тяга Т-грифа 20-18-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Отжимание от пола с блином (2-5, 5 кг) 3х15" },
            new Exercise { Name = "Пресс на перекладине 4х15, Планка 1’" },
        }
                };

                Plan plan19 = new Plan {
                    CrossDBId = "h19",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 15-12-10-8-8-8" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 3х15" },
            new Exercise { Name = "Бицепс с кривой штангой хват сверху + Молот стоя поочередно 15+10 4 серии" },
            new Exercise { Name = "Трицепс с гантелями лёжа + Трицепс-блок 15+25 3 серии" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan20 = new Plan {
                    CrossDBId = "20",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 25-20-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Жим гантель стоя + Разводка гантель стоя полная амплитуда (чередуем по 3 раза) 15+15 3 серии" },
            new Exercise { Name = "Тяга Т-грифа 8-10-12-15-20 с уменьшением веса" },
            new Exercise { Name = "Тяга 2-ух гантель лёжа на наклонной скамье лицом к полу 3х15" },
            new Exercise { Name = "Пресс на наклонной скамье с поворотами с набивным мячом 3х20, планка боковая 1’" },
        }
                };

                Plan plan21 = new Plan {
                    CrossDBId = "h21",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа 15(разминка)-4х8" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя поочередно" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "10+15+10+25 3 серии" },
            new Exercise { Name = "Пресс на перекладине 5х15; планка 1’" },
        }
                };

                Plan plan22 = new Plan {
                    CrossDBId = "h22",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель стоя 15+10 3 серии (спускаемся вниз на 1 кг)" },
            new Exercise { Name = "Жим гантель стоя 8-8-10-10-15" },
            new Exercise { Name = "Протяжка с кривой штангой средним хватом 8-8-10-10-15" },
            new Exercise { Name = "Тяга Т-грифа параллельным хватом 8-8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Тяга гантели в наклоне 8-10-12-15" },
            new Exercise { Name = "Молот стоя одновременно 8-10-12-15-20" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan23 = new Plan {
                    CrossDBId = "h23",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 8-8-10-12-15" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 15-12-10-8" },
            new Exercise { Name = "Отжимание от брусьев с резиной 3хмакс" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "10;15;20;25" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan24 = new Plan {
                    CrossDBId = "h24",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу 20-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Жим гантель стоя + Разводка гантель стоя полная амплитуда (чередуем по 3 раза) 15+15 3 серии" },
            new Exercise { Name = "Тяга Т-грифа 25-20-15-10 с уменьшением веса" },
            new Exercise { Name = "Тяга 2-ух гантель стоя одновременно 15-20-25" },
            new Exercise { Name = "Пресс на наклонной скамье с поворотами с набивным мячом 3х20, планка боковая 1’" },
        }
                };

                Plan plan25 = new Plan {
                    CrossDBId = "h25",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа 15(разминка)-4х8" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Бицепс с кривой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно нижняя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "10+(15+15) 3 серии" },
            new Exercise { Name = "Трицепс-блок 25-20-15-10" },
            new Exercise { Name = "Пресс на перекладине 5х15; планка 1’" },
        }
                };

                Plan plan26 = new Plan {
                    CrossDBId = "h26",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 3 кг 10-10-10" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "(широким, средним, узким хватом) 15+15" },
            new Exercise { Name = "Разводка гантель стоя поочередно 8-10-12-15" },
            new Exercise { Name = "Подтягивание на перекладине средним хватом с резиной 5х8" },
            new Exercise { Name = "Тяга Т-грифа параллельный хват 15-12-10-8" },
            new Exercise { Name = "Трицепс с гантелью стоя 25-20-15-12-10-8" },
            new Exercise { Name = "Вис 1’, пресс на коврике 3х30, планка 1’" },
        }
                };

                Plan plan27 = new Plan {
                    CrossDBId = "h27",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 500" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "(делаем одним весом) 15;12;10;8 с увеличением веса гантель" },
            new Exercise { Name = "Отжимание от брусьев с резиной 3хмакс" },
            new Exercise { Name = "Жим Свенда 3х2,5 или 1,25 кг 3х15" },
            new Exercise { Name = "Бицепс-кривуха на скамье Скотта 4х8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя поочередно 4х15" },
            new Exercise { Name = "(чередуем руки по 5 раз)" },
            new Exercise { Name = "Вис 1’, пресс на брусьях 4х15, Планка 1’" },
        }
                };

                Plan plan28 = new Plan {
                    CrossDBId = "h28",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель стоя 15+10 3 серии (спускаемся вниз на 1 кг)" },
            new Exercise { Name = "Жим гантель стоя 8-8-10-12-15" },
            new Exercise { Name = "Протяжка с кривой штангой широким, средним, узким хватом х 10(12) раз" },
            new Exercise { Name = "Тяга Т-грифа параллельным хватом 8-8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Тяга гантели в наклоне 8-10-12-15" },
            new Exercise { Name = "Молот стоя одновременно 8-10-12-15-20" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan29 = new Plan {
                    CrossDBId = "h29",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 8-8-10-12-15" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 15-12-10-8" },
            new Exercise { Name = "Отжимание от брусьев с резиной 3хмакс" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "10;15;20;25" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan30 = new Plan {
                    CrossDBId = "h30",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Бабочка с увеличением веса 20 15 10" },
            new Exercise { Name = "Жим гантель лёжа + Разводка гантель лёжа 8;10;12;15" },
            new Exercise { Name = "Разводка гантель стоя с большим весом (подбираем индивидуально) 4х15 1’ отдыха" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом 15;12;10;8" },
            new Exercise { Name = "Шаги-фермера со штангой с увеличением веса 15;12;10;8" },
            new Exercise { Name = "Бицепс с прямой штангой + Трицепс-блок 20;15;12;10;8" },
            new Exercise { Name = "Вис 1´; пресс на перекладине косые мышцы 3х15 в каждую сторону; планка 1´" },
        }
                };

                Plan plan31 = new Plan {
                    CrossDBId = "h31",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия 2х15" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "Жим штанги лёжа (средний вес) 3х15" },
            new Exercise { Name = "Жим гантель стоя (средний вес) 3х15" },
            new Exercise { Name = "Тяга Т-грифа шаг + 5 кг по 15 раз" },
            new Exercise { Name = "Жим ногами 40 кг 2х30" },
            new Exercise { Name = "Бицепс-кривуха стоя 15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Трицепс с гантелями лёжа 25-20-15-10 с увеличением веса" },
            new Exercise { Name = "Пресс на коврике (велосипед) 3х15 на каждую сторону" },
            new Exercise { Name = "Планка боковая 40’’ на каждую сторону" },
        }
                };

                Plan plan32 = new Plan {
                    CrossDBId = "h32",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Бабочка" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 3(4) кг" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Перекладина с резиной хват параллельный 4х8" },
            new Exercise { Name = "Отжимание от пола с блином 5 кг 4х10" },
            new Exercise { Name = "Приседания с гирей 16 кг 2х25" },
            new Exercise { Name = "Молот стоя одновременно 10-15-20-25 с уменьшением веса" },
            new Exercise { Name = "Трицепс-блок -//-//-//-" },
            new Exercise { Name = "Пресс на перекладине 4х15" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan33 = new Plan {
                    CrossDBId = "h33",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 200" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "15;12;10;8" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху широкий 5х10" },
            new Exercise { Name = "Тяга 2-ух гантель стоя в наклоне 20-15-10 с увеличением веса" },
            new Exercise { Name = "Передняя поверхность бедра шаг 10 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Задняя поверхность бедра" },
            new Exercise { Name = "25-20-15 + 15" },
            new Exercise { Name = "Бицепс с прямым грифом на скамье Скотта 15-12-10-8" },
            new Exercise { Name = "Трицепс от грифа 4х10" },
            new Exercise { Name = "Пресс на брусьях 3х15" },
            new Exercise { Name = "Планка на одной ноге 1’" },
        }
                };

                Plan plan34 = new Plan {
                    CrossDBId = "h34",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия 2х15" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "Жим штанги лёжа 15-12-10-8" },
            new Exercise { Name = "Жим гантель стоя -//-//-" },
            new Exercise { Name = "Тяга Т-грифа шаг + 5 кг старт с 10 кг 18-15-12-8" },
            new Exercise { Name = "Жим ногами 40-50-60 кг 25-20-2х10" },
            new Exercise { Name = "Бицепс-кривуха стоя 15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Трицепс с гантелями лёжа 20-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Пресс на коврике (велосипед) 3х15 на каждую сторону" },
            new Exercise { Name = "Планка боковая 40’’ на каждую сторону" },
        }
                };

                Plan plan35 = new Plan {
                    CrossDBId = "h35",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Бабочка" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 4(5) кг" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Отжимание от пола с блином 8 кг 5х10" },
            new Exercise { Name = "Приседания с гирей 20 кг 2х25" },
            new Exercise { Name = "Молот стоя одновременно 10-15-20-25 с уменьшением веса" },
            new Exercise { Name = "Трицепс-блок -//-//-//-" },
            new Exercise { Name = "Пресс на перекладине 4х15" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan36 = new Plan {
                    CrossDBId = "h36",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 200" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа 10+10 2 серии" },
            new Exercise { Name = "8+8 2 серии" },
            new Exercise { Name = "Тяга вертикальная к груди хват обратный 15-12-10-8" },
            new Exercise { Name = "Турецкие подтягивания 5х8" },
            new Exercise { Name = "Выпады в Смитте 3х15" },
            new Exercise { Name = "Бицепс с прямым грифом 15-12-10-8" },
            new Exercise { Name = "Трицепс от грифа 4х12" },
            new Exercise { Name = "Пресс на брусьях 3х15" },
            new Exercise { Name = "Планка на одной ноге 1’" },
        }
                };

                Plan plan37 = new Plan {
                    CrossDBId = "h37",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 3х15" },
            new Exercise { Name = "Разводка гантель лёжа с увеличением веса 15-12-10-8-6" },
            new Exercise { Name = "Жим гантель лёжа 3х8" },
            new Exercise { Name = "Отжимание с блином 8-10 кг 5х8(10)" },
            new Exercise { Name = "Тяга Т-грифа хват классический старт с 10 кг шаг 5-2,5-2,5 кг 15-12-10-8" },
            new Exercise { Name = "Бицепс с прямым грифом хват сверху 5х8" },
            new Exercise { Name = "Трицепс с гантелью стоя 8-10-12-15-25 с уменьшением веса" },
            new Exercise { Name = "Пресс, вис, планка" },
        }
                };

                Plan plan38 = new Plan {
                    CrossDBId = "h38",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель стоя 10+15 3 серии" },
            new Exercise { Name = "Протяжка с кривой штангой 4х8" },
            new Exercise { Name = "Жим штанги стоя 4х8" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно" },
            new Exercise { Name = "25-20-15 + 15" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan39 = new Plan {
                    CrossDBId = "h39",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Сведение рук стоя" },
            new Exercise { Name = "15+15; 12+15; 10+15" },
            new Exercise { Name = "Жим штанги лёжа на наклонной скамье 25-20-15 средним весом" },
            new Exercise { Name = "Бицепс с прямой штангой 10" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя поочередно 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью стоя 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan40 = new Plan {
                    CrossDBId = "h40",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье лицом к полу" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отведение руки лёжа" },
            new Exercise { Name = "25-20-15-10 + 15-12-10-8" },
            new Exercise { Name = "Протяжка-кривуха широким хватом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя одновременно" },
            new Exercise { Name = "15+15; 12+12;10+10;8+8" },
            new Exercise { Name = "Тяга Т-грифа параллельный хват 18-15-12-10-8" },
            new Exercise { Name = "Тяга гантели в наклоне 8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Пресс-велосипед 5х20 в каждую сторону" },
            new Exercise { Name = "Планка 1,5’" },
        }
                };

                Plan plan41 = new Plan {
                    CrossDBId = "h41",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от лежака широким хватом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "10+15+10 3 серии" },
            new Exercise { Name = "Тяга штанги к поясу с увеличением веса 18-15-12-10-8" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом 8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Шраги с гантелями 10-12-15 кг 3х25" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan42 = new Plan {
                    CrossDBId = "h42",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка стоя полная амплитуда" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка-кривуха" },
            new Exercise { Name = "15 + 8-10-12-15" },
            new Exercise { Name = "Отведение руки в блоке 3х15" },
            new Exercise { Name = "Бицепс с прямой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями сидя на наклонной скамье" },
            new Exercise { Name = "10+15 3 серии" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan43 = new Plan {
                    CrossDBId = "h43",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа полуамплитуда 15-12-10-8-6" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 4х8" },
            new Exercise { Name = "Бабочка 2х25" },
            new Exercise { Name = "Бицепс с кривой штангой 5+5+5" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с кривой штангой 5+5+5" },
            new Exercise { Name = "3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan44 = new Plan {
                    CrossDBId = "h44",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель стоя 8+12 4 серии" },
            new Exercise { Name = "Жим гантель сидя в упоре 15-12-10-8-8-15" },
            new Exercise { Name = "Перекладина широким хватом 5х10" },
            new Exercise { Name = "Тяга Т-грифа классический хват 18-15-12-10-8" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом 15-12-10" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan45 = new Plan {
                    CrossDBId = "h45",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "6+6;8+8;10+10;15+15" },
            new Exercise { Name = "Сведение рук стоя в тренажере 8-10-12-15" },
            new Exercise { Name = "Бицепс с прямой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями сидя на наклонной скамье" },
            new Exercise { Name = "10+15 3 серии" },
            new Exercise { Name = "Бицепс с грифом в наклоне 3х15" },
            new Exercise { Name = "Кисти штанга сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan46 = new Plan {
                    CrossDBId = "h46",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 15-15-15" },
            new Exercise { Name = "Жим штанги стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "8+12+15 3 серии" },
            new Exercise { Name = "Отжимание от пола на дельты 3х15" },
            new Exercise { Name = "Перекладина с резиной широким хватом 4х8 1’ отдыха" },
            new Exercise { Name = "Тяга Т-грифа II хват 18-15-12-10-8-8 1’ отдыха" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan47 = new Plan {
                    CrossDBId = "h47",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг" },
            new Exercise { Name = "Жим гантель сидя в упоре" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с прямым грифом средним хватом" },
            new Exercise { Name = "Разводка гантель сидя" },
            new Exercise { Name = "15;12;10;8" },
            new Exercise { Name = "Отведение руки лёжа с упором на скамью 3х15 3(4) кг" },
            new Exercise { Name = "Тяга Т-грифа 18-15-12-10-8 + 5 кг, старт с 10 кг" },
            new Exercise { Name = "Турецкие подтягивания 4х8" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan48 = new Plan {
                    CrossDBId = "h48",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Бабочка с увеличением веса 15-12-10-8" },
            new Exercise { Name = "Жим штанги лёжа 6-8-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье полуамплитуда 10-12-15-20" },
            new Exercise { Name = "Бицепс-кривуха хват сверху" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "15-12-10-8 + 25-20-15-10" },
            new Exercise { Name = "Кисти с грифом хват сверху 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan49 = new Plan {
                    CrossDBId = "h49",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 1,5 кг 15-15-15" },
            new Exercise { Name = "Жим штанги стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка (можно брать как кривуху так и прямую, ту же с которой выполняете жим)" },
            new Exercise { Name = "15;12;10;8" },
            new Exercise { Name = "Тяга Т-грифа хват классический (старт с 15 кг, шаг +5 кг) 18-15-12-10-8" },
            new Exercise { Name = "Тяга 2-ух гантель с упором лбом на лежак 15-12-10-8-8" },
            new Exercise { Name = "Французский жим лёжа с кривой штангой 18-15-12-10-8" },
            new Exercise { Name = "Трицепс с гантелями стоя в наклоне 3-4 кг 3х15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan50 = new Plan {
                    CrossDBId = "h50",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Бабочка 2х15 средним весом" },
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 8-10-12-15-18 1’ отдыха" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье полуамплитуда 8-10-12-15-20" },
            new Exercise { Name = "Отжимание от лежака широким хватом 5х12" },
            new Exercise { Name = "Бицепс с прямой штангой 5-5-5х3 серии" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя одновременно с блином 15 кг по 15 раз" },
            new Exercise { Name = "Кисти штанга сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan51 = new Plan {
                    CrossDBId = "h51",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "6;8;10;12;15" },
            new Exercise { Name = "Жим гантель лёжа с отрицательным наклоном 3х15" },
            new Exercise { Name = "Жим гантель лёжа с отрицательным наклоном 3х15" },
            new Exercise { Name = "Бицепс с прямой штангой 5-5-5 х 3 серии" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа 25-20-15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan52 = new Plan {
                    CrossDBId = "h52",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель стоя 4х15; 20; 25 30’’ отдыха" },
            new Exercise { Name = "Жим штанги стоя за голову 15-12-10-8" },
            new Exercise { Name = "Протяжка с кривой штангой 25-20-15-10 широким хватом" },
            new Exercise { Name = "Тяга Т-грифа 18-15-12-10-8" },
            new Exercise { Name = "Тяга гантели в наклоне 10-15-20" },
            new Exercise { Name = "Молот стоя одновременно" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan53 = new Plan {
                    CrossDBId = "h53",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Отжимание на брусьях 3хмах" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "8;10;12;15" },
            new Exercise { Name = "Разводка гантель стоя 3х15; 20;25" },
            new Exercise { Name = "Бицепс с прямой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "5-5-5 + 15 3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan54 = new Plan {
                    CrossDBId = "h54",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Подтягивание на перекладине с резиной широким хватом" },
            new Exercise { Name = "15-20-25 + 10" },
            new Exercise { Name = "Разводка гантель лёжа с упором на лежак (задняя дельта) 25-20-15-10 (делаем медленно)" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга Т-грифа хват классический" },
            new Exercise { Name = "15 + 15 3 серии" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями сидя на наклонной скамье" },
            new Exercise { Name = "25;20;15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan55 = new Plan {
                    CrossDBId = "h55",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель с отрицательным наклоном 3х15" },
            new Exercise { Name = "Жим гантель с положительным наклоном 3х10" },
            new Exercise { Name = "Жим штанги лёжа 3х8" },
            new Exercise { Name = "Разводка гантель лёжа полуамплитуда 15-20-25" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan56 = new Plan {
                    CrossDBId = "h56",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель в наклоне" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отведение руки назад лёжа" },
            new Exercise { Name = "15+15 3 серии" },
            new Exercise { Name = "Разводка гантель стоя с рабочим весом 4х15 40’’ отдыха - уменьшаем вес гантель 20-25" },
            new Exercise { Name = "Жим штанги стоя за голову 18-15-12-10" },
            new Exercise { Name = "Тяга штанги к поясу обратным хватом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом" },
            new Exercise { Name = "18;15;12;10" },
            new Exercise { Name = "Бицепс с гантелями сидя на наклонной скамье 25-20-15 1’ отдыха" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan57 = new Plan {
                    CrossDBId = "h57",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "8+12+15 3 серии" },
            new Exercise { Name = "Тяга Т-грифа хват классический 18-15-12-10-8-8" },
            new Exercise { Name = "Тяга гантели в наклоне 8-8-10-12" },
            new Exercise { Name = "Пресс на перекладине 3х25" },
            new Exercise { Name = "Планка боковая 1’" },
        }
                };

                Plan plan58 = new Plan {
                    CrossDBId = "h58",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "6-8-10-12-15" },
            new Exercise { Name = "Жим штанги лёжа" },
            new Exercise { Name = "8-8-10-10" },
            new Exercise { Name = "Отжимание на брусьях с резиной" },
            new Exercise { Name = "3хмах" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно" },
            new Exercise { Name = "по 15 раз 3 круга" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan59 = new Plan {
                    CrossDBId = "h59",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 15-15-15" },
            new Exercise { Name = "Задняя дельта в Смите 25;20;15;10" },
            new Exercise { Name = "Жим штанги стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "12;10;8;8" },
            new Exercise { Name = "Перекладина узким обратным хватом 5х8" },
            new Exercise { Name = "Тяга Т-грифа" },
            new Exercise { Name = "15;12;10;8;8" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan60 = new Plan {
                    CrossDBId = "h60",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "8+8 3 серии" },
            new Exercise { Name = "Отжимание на брусьях 3хмах" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно 25;20;15;10" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan61 = new Plan {
                    CrossDBId = "h61",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 15-15-15" },
            new Exercise { Name = "Разводка гантель стоя 10+15 3 серии" },
            new Exercise { Name = "Жим гантель стоя 8-8-10-12" },
            new Exercise { Name = "Перекладина широким хватом 4х10" },
            new Exercise { Name = "Тяга штанги к поясу 12-10-8-8-8" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 15-12-10-8" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan62 = new Plan {
                    CrossDBId = "h62",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "8-8-10-15" },
            new Exercise { Name = "Жим штанги лёжа на наклонной скамье 3х8" },
            new Exercise { Name = "Отжимание с блином 8(10) кг 5х12" },
            new Exercise { Name = "Бицепс с прямой штангой хват сверху" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя поочерёдно по 3 раза" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от лежака" },
            new Exercise { Name = "10+15+12+25 3 серии" },
            new Exercise { Name = "Кисти штанга сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan63 = new Plan {
                    CrossDBId = "h63",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Бабочка 2х15" },
            new Exercise { Name = "Разводка гантель лёжа 3х8" },
            new Exercise { Name = "Жим гантель лёжа 3х8" },
            new Exercise { Name = "Отжимание на брусьях с резиной 3хмах" },
            new Exercise { Name = "Бицепс с гантелями стоя поочерёдно по 5 раз на руку" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим штанги лёжа узким хватом" },
            new Exercise { Name = "15+8-10-12-15" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan64 = new Plan {
                    CrossDBId = "h64",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 3 кг 15-15-15" },
            new Exercise { Name = "Разводка гантель лёжа с упором на лежак" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина широким хватом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Задняя дельта в Смите" },
            new Exercise { Name = "15+10+15 3(4) круга" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой средним хватом" },
            new Exercise { Name = "8+12 3 серии" },
            new Exercise { Name = "Тяга штанги в наклоне обратным хватом 15-4х8" },
            new Exercise { Name = "Тяга 2-ух гантель в наклоне 8-10-12-15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan65 = new Plan {
                    CrossDBId = "h65",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа 15-12-8-8" },
            new Exercise { Name = "Жим гантель лёжа (в таком же порядке весов что и на разводке обратно) 8-8-12-15" },
            new Exercise { Name = "Отжимание на брусьях 3хмах" },
            new Exercise { Name = "Трицепс-блок одной рукой обратным хватом 18-15-12-10-8" },
            new Exercise { Name = "Трицепс с гантелями стоя в наклоне 2х25 (3-4 кг не больше)" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan66 = new Plan {
                    CrossDBId = "h66",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Отведение руки в кроссовере 15-12-10-8 1’ или 40’’ отдыха" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "15+10" },
            new Exercise { Name = "4 серии" },
            new Exercise { Name = "Перекладина параллельный хват (подтягивайте грудь к перекладине) 5х8" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 15-12-10-8" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя поочерёдно по 5 раз" },
            new Exercise { Name = "15+15" },
            new Exercise { Name = "3 серии" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan67 = new Plan {
                    CrossDBId = "h67",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа 8-8-6-6-15" },
            new Exercise { Name = "Жим гантель лёжа 4х8" },
            new Exercise { Name = "Отжимание на брусьях 3хмах" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "15+15 х 3 круга" },
            new Exercise { Name = "Трицепс от лежака 2х25" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan68 = new Plan {
                    CrossDBId = "h68",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч" },
            new Exercise { Name = "Разводка гантель в упоре на лежак 3х15" },
            new Exercise { Name = "Жим гантель стоя 8-8-10-10-12-15" },
            new Exercise { Name = "Перекладина хват сверху средний с резиной 5х8" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 8-8-10-10-15" },
            new Exercise { Name = "Бицепс с прямой штангой хват сверху" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя в наклоне одной рукой" },
            new Exercise { Name = "10 + 8-10-12-15" },
            new Exercise { Name = "Кисти с грифом сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan69 = new Plan {
                    CrossDBId = "h69",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа в Смите с положительным наклоном 18-15-12-10-8 1’ отдыха" },
            new Exercise { Name = "Разводка гантель стоя 4х15 30’’ отдыха" },
            new Exercise { Name = "Перекладина широким хватом с резиной 4х10" },
            new Exercise { Name = "Бицепс-кривуха 5-5-5 х 3 1’ отдыха" },
            new Exercise { Name = "Бицепс с гантелью стоя в наклоне без отдыха 3х15" },
            new Exercise { Name = "Отжимания узким хватом с упором на лежак 4х15 30(40)’’ отдыха" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan70 = new Plan {
                    CrossDBId = "h70",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа в Смите 18-15-12-10-8-8" },
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье 12-10-8-8" },
            new Exercise { Name = "Сведение рук в кроссовере 15-12-10" },
            new Exercise { Name = "Бицепс с прямой штангой 5-5-5" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Французский жим лёжа с кривухой 8-10-12-15" },
            new Exercise { Name = "Кисти штанга сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan71 = new Plan {
                    CrossDBId = "h71",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель лёжа на наклонной скамье полуамплитуда 18-15-12-10-8" },
            new Exercise { Name = "Отжимание от брусьев 3хмах" },
            new Exercise { Name = "Протяжка с кривой штангой 15-12-10" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом-//-//-//-" },
            new Exercise { Name = "Бицепс с прямой штангой 5-5-5 х 3 круга" },
            new Exercise { Name = "Молот стоя поочерёдно 10+5 х 3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan72 = new Plan {
                    CrossDBId = "h72",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разводка гантель стоя 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя попеременно 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга в Смите на заднюю дельту (будет занят, тогда прямую штангу) 18" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Тяга Т-грифа 18-15-12-10-8" },
            new Exercise { Name = "Тяга 2-ух гантель с упором на лежак 3х15" },
            new Exercise { Name = "Трицепс от грифа 5х18" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan73 = new Plan {
                    CrossDBId = "h73",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа 8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа 12" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 4х12" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху 3х12" },
            new Exercise { Name = "Молот сидя поочерёдно по 5 раз 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс на перекладине (косые мышцы) 4х15 на каждую сторону" },
            new Exercise { Name = "Планка на прямых руках 1’" },
        }
                };

                Plan plan74 = new Plan {
                    CrossDBId = "h74",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "8+8 3 круга" },
            new Exercise { Name = "Тяга в Смите за спиной на заднюю дельту 18-15-12-10" },
            new Exercise { Name = "Тяга Т-грифа 15-15-12-10-8" },
            new Exercise { Name = "Бицепс с прямым грифом хват сверху" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "12+15 3 круга" },
            new Exercise { Name = "Кисти с грифом сидя 3хмаксимум" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan75 = new Plan {
                    CrossDBId = "h75",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "8+8 х 3" },
            new Exercise { Name = "Разводка гантель сидя полная амплитуда 3х12" },
            new Exercise { Name = "Бицепс с кривухой 4-4-4 х 3" },
            new Exercise { Name = "Бицепс с гантелью стоя в наклоне 3х12 без отдыха" },
            new Exercise { Name = "Кисти с грифом сидя 3 х макс" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan76 = new Plan {
                    CrossDBId = "h76",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 10-10-10" },
            new Exercise { Name = "Жим гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой 12+12 х 3" },
            new Exercise { Name = "Перекладина широким хватом с резиной 5х6" },
            new Exercise { Name = "Тяга Т-грифа 15-12-10-8-8" },
            new Exercise { Name = "Трицепс от грифа 5х12" },
            new Exercise { Name = "Шраги с тяжелыми гантелями 4х14(18)" },
            new Exercise { Name = "Пресс, планка на своё усмотрение" },
        }
                };

                Plan plan77 = new Plan {
                    CrossDBId = "h77",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "8;10;12;15 начиная с максимального веса гантель" },
            new Exercise { Name = "Разводка гантель с упором на наклонную скамью на заднюю дельту 25-20-15-10" },
            new Exercise { Name = "Задняя дельта в Смите 3х15" },
            new Exercise { Name = "Тяга вертикальная к груди широким хватом 18-15-12-10" },
            new Exercise { Name = "Бицепс-кривуха 4-4-4" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan78 = new Plan {
                    CrossDBId = "h78",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим лёжа в Смите" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пуловер лёжа поперёк скамьи с гантелью" },
            new Exercise { Name = "12+12х3" },
            new Exercise { Name = "Разводка гантель лёжа с уменьшением веса 8-10-12-15-18" },
            new Exercise { Name = "Разводка стоя полная амплитуда сидя 3х12" },
            new Exercise { Name = "Молот сидя с упором спиной поочередно по 5 раз 3х15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan79 = new Plan {
                    CrossDBId = "h79",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг:10-10-10" },
            new Exercise { Name = "Жим штанги стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "8+8;10+10;12+12;15+15" },
            new Exercise { Name = "Разводка гантель с упором на лежак (задняя дельта) 3х15" },
            new Exercise { Name = "Тяга вертикальная к груди с увеличением веса 15-12-10-8-8" },
            new Exercise { Name = "Тяга 2-ух гантель с упором лба на лежак 15-12-10-10(8)" },
            new Exercise { Name = "Трицепс от грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа" },
            new Exercise { Name = "15+15х3" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan80 = new Plan {
                    CrossDBId = "h80",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 10-10-10" },
            new Exercise { Name = "Жим штанги стоя 12-10-8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина хват сверху средний 12-12-10 (если не получится, то можно делать по 8 раз)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка стоя 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга вертикальная к груди хват сверху средний 12-10-8" },
            new Exercise { Name = "Бицепс с прямым грифом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью одной рукой" },
            new Exercise { Name = "15-12-10-8" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan81 = new Plan {
                    CrossDBId = "h81",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "8+8 х 3" },
            new Exercise { Name = "Пуловер поперек скамьи 8-10-12 с уменьшением веса" },
            new Exercise { Name = "Отжимание от брусьев (можно с резиной) 3х12(15)" },
            new Exercise { Name = "Протяжка с кривой штангой 8-8-10-12" },
            new Exercise { Name = "Разводка гантель сидя 3х12" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan82 = new Plan {
                    CrossDBId = "h82",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч 10-10-10" },
            new Exercise { Name = "Разводка стоя 8+12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина 8" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Жим гантель стоя 2х8; 2х10;12;15" },
            new Exercise { Name = "Тяга Т-грифа параллельный хват с уменьшением веса 8-8-10-12-15" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок 18(15)" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Кисти с грифом сидя хват сверху 3хmax" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan83 = new Plan {
                    CrossDBId = "h83",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа 2-5-8-10-12-15" },
            new Exercise { Name = "Пуловер поперек скамьи 3х12" },
            new Exercise { Name = "Разводка гантель с упором на лежак на заднюю дельту 3х15" },
            new Exercise { Name = "Разводка гантель лежа 3х8" },
            new Exercise { Name = "Бицепс-кривуха 4-4-4" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот с блином 15 кг 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan84 = new Plan {
                    CrossDBId = "h84",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "12;10; 2х8" },
            new Exercise { Name = "Тяга на заднюю дельту в Смите 3х15" },
            new Exercise { Name = "Разводка гантель стоя поочерёдно 8+10+12 х 2 круга" },
            new Exercise { Name = "Бицепс с гантелями стоя в упоре на конструкцию тренажёра Смит" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью стоя" },
            new Exercise { Name = "20; 18; 15" },
            new Exercise { Name = "Кисти штанга хват сверху 3 х max" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan85 = new Plan {
                    CrossDBId = "h85",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями" },
            new Exercise { Name = "Жим штанги стоя за голову 15-12-10-8-8" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 8/10/12/15 с уменьшением веса" },
            new Exercise { Name = "Тяга Т-грифа 2х8/10/12/15" },
            new Exercise { Name = "Тяга гантели в наклоне-//-//-" },
            new Exercise { Name = "Молот стоя одновременно 4х8" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan86 = new Plan {
                    CrossDBId = "h86",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Жим + Разводка гантель лёжа 2х6+6; 2х8+8" },
            new Exercise { Name = "Пуловер поперек скамьи 3х12" },
            new Exercise { Name = "Отжимания от брусьев (можно попробовать с блином 5 кг) 3хмакс но не менее 8 раз" },
            new Exercise { Name = "Тяга кривой штанги в наклоне на заднюю дельту 3х15(12)" },
            new Exercise { Name = "Бицепс с гантелями сидя на наклонной скамье 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью стоя с уменьшением веса 12-15-18" },
            new Exercise { Name = "Кисти с грифом сидя 3хмакс" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan87 = new Plan {
                    CrossDBId = "h87",
                    Category = "Hands",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда чередуем по разу 12+12 х 3" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина хват сверху средний 8" },
            new Exercise { Name = "Жим гантель сидя 4х8" },
            new Exercise { Name = "Протяжка с кривой штангой хват узкий 3х12(10)" },
            new Exercise { Name = "Тяга штанги к поясу обратным хватом 15-12-10-8-8" },
            new Exercise { Name = "Бицепс с гантелью стоя в наклоне" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями стоя в наклоне" },
            new Exercise { Name = "15+18х3" },
            new Exercise { Name = "Пресс, планка" },
        }
                };



                db.Plans.AddRange(plan1, plan2, plan3, plan4, plan5, plan6, plan7, plan8,
            plan9, plan10, plan11, plan12, plan13, plan14, plan15, plan16, plan17,
            plan18, plan19, plan20, plan21, plan22, plan23, plan24, plan25, plan26,
            plan27, plan28, plan29, plan30, plan31, plan32, plan33, plan34, plan35,
            plan36, plan37, plan38, plan39, plan40, plan41, plan42, plan43, plan44,
            plan45, plan46, plan47, plan48, plan49, plan50, plan51, plan52, plan53,
            plan54, plan55, plan56, plan57, plan58, plan59, plan60, plan61, plan62,
            plan63, plan64, plan65, plan66, plan67, plan68, plan69, plan70, plan71,
            plan72, plan73, plan74, plan75, plan76, plan77, plan78, plan79, plan80,
            plan81, plan82, plan83, plan84, plan85, plan86, plan87);
                db.SaveChanges();
                Plan plan88 = new Plan {
                    CrossDBId = "l1",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Передняя поверхность бедра + Гиперэкстензия блин 8 кг 25-20-15-10+15" },
            new Exercise { Name = "Жим ногами 30-25-20-15-15-10-10" },
            new Exercise { Name = "Шаги-фермера с гантелями 5х8(10) вес гантель максимум" },
            new Exercise { Name = "ПВП (пресс, вис, планка)" },
        }
                };



                Plan plan89 = new Plan {
                    CrossDBId = "l2",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х25" },
            new Exercise { Name = "Присед штанга на плечах (глубокий) 25-20-15-12-10" },
            new Exercise { Name = "Выпады в Смитте 15-12-10-8" },
            new Exercise { Name = "Задняя поверхность бедра 3х15" },
            new Exercise { Name = "Икры, пресс, вис" },
        }
                };

                Plan plan90 = new Plan {
                    CrossDBId = "l3",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Гиперэкстензия 2х25" },
            new Exercise { Name = "Приседания с гирей 22-24 кг 5х20 (можно брать стул для подстраховки)" },
            new Exercise { Name = "Выпады с гантелями стоя без смены ног 15-12-10-8 с увеличением веса гантель" },
            new Exercise { Name = "М.тяга с гирей (также как и на приседе) 5х20" },
            new Exercise { Name = "Икры в тренажере 3х30 (в спокойном темпе)" },
            new Exercise { Name = "ПВП" },
        }
                };

                Plan plan91 = new Plan {
                    CrossDBId = "l4",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Передняя поверхность бедра 25-20-15-10" },
            new Exercise { Name = "Жим ногами 50-25-20-15-12-10-8" },
            new Exercise { Name = "Выпады в Смитте без смены ног 15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Гиперэкстензия 25-20-15 (вес тела-5 кг-8 кг)" },
            new Exercise { Name = "Пресс, планка (на своё усмотрение)" },
        }
                };

                Plan plan92 = new Plan {
                    CrossDBId = "l5",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 200" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Передняя поверхность бедра 15 кг + Задняя поверхность бедра 15+10 3 серии" },
            new Exercise { Name = "Шаги-фермера с гантелями 5х10 на каждую ногу (7-8-9-10-12 кг)" },
            new Exercise { Name = "М.тяга с гирей 22 кг 4х15" },
            new Exercise { Name = "Икры в тренажере 3х25" },
            new Exercise { Name = "Пресс на перекладине 5х15; планка 1’" },
        }
                };

                Plan plan93 = new Plan {
                    CrossDBId = "l6",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Гиперэкстензия 25-20-15-10 (вес тела-5-10-15 кг)" },
            new Exercise { Name = "Выпады с гантелями стоя без смены ног ( задняя нога на шплинте) 20-15-12-10-8" },
            new Exercise { Name = "Передняя поверхность бедра одной ногой 25-20-15-10 с небольшим увеличением веса" },
            new Exercise { Name = "Икры в тренажере 3х30" },
            new Exercise { Name = "Пресс, планка, растяжка" },
        }
                };

                Plan plan94 = new Plan {
                    CrossDBId = "l7",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х25" },
            new Exercise { Name = "Присед штанга на груди 15-12-10-8-6-15" },
            new Exercise { Name = "Румынская тяга с кривой штангой с увеличением веса 18-15-12-10" },
            new Exercise { Name = "Передняя поверхность бедра одной ногой 3х15" },
            new Exercise { Name = "Икры, ПВП" },
        }
                };

                Plan plan95 = new Plan {
                    CrossDBId = "l8",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Гиперэкстензия блин 5-8-10кг х 15" },
            new Exercise { Name = "Приседания у шведской стенки на одной ноге 4х5" },
            new Exercise { Name = "Задняя поверхность бедра максимальным весом 4х8" },
            new Exercise { Name = "Шаги-фермера с гантелями 8-10-12-15 (начинаем с самых тяжелых гантель)" },
            new Exercise { Name = "М.тяга со штангой 30-35-40-45-50 х 15-15-12-10-8" },
            new Exercise { Name = "Икры в тренажере 3х20" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan96 = new Plan {
                    CrossDBId = "l9",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Присед Зерчера (возьмите с собой каждый по полотенцу) 15-12-10-8" },
            new Exercise { Name = "Передняя поверхность бедра одной ногой без отдыха 3х15" },
            new Exercise { Name = "М.тяга с гирей 24-28 кг" },
            new Exercise { Name = "Икры с гантелями стоя 3хмакс" },
            new Exercise { Name = "Вис 1’, пресс на наклонной скамье с поворотами 3х20, планка 1’" },
        }
                };

                Plan plan97 = new Plan {
                    CrossDBId = "l10",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Присед Зерчера (берём полотенце) 15-12-10-8 с увеличением веса (можно взять гриф 13,5 кг)" },
            new Exercise { Name = "Передняя поверхность бедра 10-12-15-20-25 с уменьшением веса" },
            new Exercise { Name = "М.тяга с гирей 28 кг 3х20" },
            new Exercise { Name = "Пресс на перекладине косые мышцы 3х15, планка 1’" },
        }
                };

                Plan plan98 = new Plan {
                    CrossDBId = "l11",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х25" },
            new Exercise { Name = "Присед штанга на плечах (глубокий) 15-12-10-8" },
            new Exercise { Name = "Выпады в Смитте 15-12-10-8" },
            new Exercise { Name = "Задняя поверхность бедра 3х15" },
            new Exercise { Name = "Икры 3х25" },
            new Exercise { Name = "Пресс, вис" },
        }
                };

                Plan plan99 = new Plan {
                    CrossDBId = "l12",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х20" },
            new Exercise { Name = "Присед Зерчера (берём полотенце) 15(гриф)-12-10-8-6-15(гриф) с увеличением веса (можно взять гриф 13,5 кг)" },
            new Exercise { Name = "Выпады со штангой без смены ног 15-12-10-8" },
            new Exercise { Name = "Передняя поверхность бедра 10-12-15-20-25 с уменьшением веса" },
            new Exercise { Name = "Икры в тренажере 3х20" },
            new Exercise { Name = "Пресс на перекладине косые мышцы 3х15, планка 1’" },
        }
                };

                Plan plan100 = new Plan {
                    CrossDBId = "l13",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Жим ногами 25-20-15-12-10-8 (вес подбираем самостоятельно)" },
            new Exercise { Name = "Шаги-фермера с гантелями 15-12-10 кг х 10-12-15" },
            new Exercise { Name = "М.тяга с гирей 26-28 кг 25-20-15 40’’ отдыха" },
            new Exercise { Name = "Икры 3хмакс" },
            new Exercise { Name = "Пресс на перекладине 4х15, планка 1’" },
        }
                };

                Plan plan101 = new Plan {
                    CrossDBId = "l14",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Передняя поверхность бедра 25-20-15-10" },
            new Exercise { Name = "Присед Зерчера 15-12-10-8-6-15" },
            new Exercise { Name = "М.тяга со штангой 40-45-50-55-60 кг х 15-12-10-8-2х6" },
            new Exercise { Name = "Икры в тренажере 3х25" },
            new Exercise { Name = "Пресс на перекладине косые мышцы 3х15; планка боковая 1’" },
        }
                };

                Plan plan102 = new Plan {
                    CrossDBId = "l15",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х25" },
            new Exercise { Name = "Присед штанга на плечах (глубокий) 15-12-10-8" },
            new Exercise { Name = "Выпады в Смитте 15-12-10-8" },
            new Exercise { Name = "Задняя поверхность бедра 3х15" },
            new Exercise { Name = "Икры 3х25" },
            new Exercise { Name = "Пресс, вис" },
        }
                };

                Plan plan103 = new Plan {
                    CrossDBId = "l16",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Задняя поверхность бедра" },
            new Exercise { Name = "15+10 3 серии" },
            new Exercise { Name = "Шаги-фермера с гантелями с увеличением веса 15-12-10-8" },
            new Exercise { Name = "М.тяга с олимпийским грифом 15-12-10-8-6" },
            new Exercise { Name = "Икры 3хmax" },
            new Exercise { Name = "Пресс, планка, вис" },
        }
                };

                Plan plan104 = new Plan {
                    CrossDBId = "l17",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Задняя поверхность бедра" },
            new Exercise { Name = "15+15-12-10-8" },
            new Exercise { Name = "Приседания штанга на плечах на стул 15-12-10-8-6" },
            new Exercise { Name = "Мертвая тяга со штангой 15-12-10-8" },
            new Exercise { Name = "Икры 3хmax" },
            new Exercise { Name = "Пресс на перекладине 5х20 1’ отдыха" },
            new Exercise { Name = "Планка боковая 40’’" },
        }
                };

                Plan plan105 = new Plan {
                    CrossDBId = "l18",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Передняя поверхность бедра 25-20-15-10 (не убирайте блины - понадобятся позже)" },
            new Exercise { Name = "Присед Зерчера 15-12-10-8-6" },
            new Exercise { Name = "Выпады в Смитте 3х8 без отдыха" },
            new Exercise { Name = "Передняя поверхность бедра 10-15-20-25" },
            new Exercise { Name = "Пресс на коврике (велосипед + скручивания) 20+20 3 серии" },
            new Exercise { Name = "Планка 1,5’" },
        }
                };

                Plan plan106 = new Plan {
                    CrossDBId = "l19",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Приседания со штангой на плечах 15-12-10-8-6" },
            new Exercise { Name = "Мертвая тяга со штангой-//-//-" },
            new Exercise { Name = "Передняя поверхность бедра 10-15-20-25 с уменьшением веса" },
            new Exercise { Name = "Пресс, планка, икры" },
        }
                };

                Plan plan107 = new Plan {
                    CrossDBId = "l20",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Передняя поверхность бедра 25-20-15-10 (и не убирай свои блины)" },
            new Exercise { Name = "Присед штанга на груди 15-12-10-8-6" },
            new Exercise { Name = "Передняя поверхность бедра 10-15-20-25" },
            new Exercise { Name = "М. тяга штанга с пола 4х8 (предмаксимальный стартовый вес ~ ну наверное 60 кг)" },
            new Exercise { Name = "Икры 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan108 = new Plan {
                    CrossDBId = "l21",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Передняя поверхность бедра с увеличением веса 25-20-15-10" },
            new Exercise { Name = "Шаги-фермера со штангой 15-12-10-8-6" },
            new Exercise { Name = "Румынская тяга на Т-грифе 20-18-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Икры со штангой 3хмах 40(50) кг" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan109 = new Plan {
                    CrossDBId = "l22",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Передняя поверхность бедра 25-20-15-10 (блины оставляем на месте)" },
            new Exercise { Name = "Шаги-фермера с гантелями 15-12-10 кг х 2х8-10-15" },
            new Exercise { Name = "Передняя поверхность бедра 10-15-20-25" },
            new Exercise { Name = "Икры, ПВП" },
        }
                };

                Plan plan110 = new Plan {
                    CrossDBId = "l23",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Задняя поверхность бедра 3х12" },
            new Exercise { Name = "Шаги-фермера с гантелями с увеличением веса 15-12-10-8-6" },
            new Exercise { Name = "Присед с блином 10-8-5 кг с упором в лежак 10-15-20" },
            new Exercise { Name = "Передняя поверхность бедра одной ногой 3х10 без отдыха" },
            new Exercise { Name = "Икры в тренажёре 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan111 = new Plan {
                    CrossDBId = "l24",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Передняя поверхность бедра" },
            new Exercise { Name = "25-20-15-10 + 10-15-20-25" },
            new Exercise { Name = "Жим ногами 25-20-15-12-10-8" },
            new Exercise { Name = "М.тяга со штангой 15-12-10-8" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan112 = new Plan {
                    CrossDBId = "l25",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 3х15" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 3х15 8-10-12-15" },
            new Exercise { Name = "Выпады в Смитте 8-10-12-15" },
            new Exercise { Name = "М.тяга со штангой 15-12-10-8-6" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan113 = new Plan {
                    CrossDBId = "l26",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Жим ногами" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Передняя поверхность бедра" },
            new Exercise { Name = "(оба движения начинаем с максимальными весами и уменьшаем) 8-10-12-15-20-25" },
            new Exercise { Name = "Тяга с гантелями на одной ноге 12-10-8 кг x 15-18-25" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan114 = new Plan {
                    CrossDBId = "l27",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Передняя поверхность бедра 8-10-12-15-18-20-25" },
            new Exercise { Name = "Шаги-фермера со штангой 8-10-12-15" },
            new Exercise { Name = "М.тяга со штангой 15-12-10-8" },
            new Exercise { Name = "Задняя поверхность бедра 3х8" },
            new Exercise { Name = "Икры 3хмах" },
            new Exercise { Name = "Пресс на коврике: пулловер + подъемы ног" },
            new Exercise { Name = "20+10 3 серии" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan115 = new Plan {
                    CrossDBId = "l28",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 5-8-10 кг Х 25-20-15" },
            new Exercise { Name = "Приседания с гантелью 20-15-12 кг под пятки блины по 5 кг 10-12-15" },
            new Exercise { Name = "Шаги-фермера с гантелями 5х8 вес максимальный" },
            new Exercise { Name = "М.тяга со штангой 40-45-50-55-60 кг 15-12-20-8-6" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan116 = new Plan {
                    CrossDBId = "l29",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Гиперэкстензия блин 5 кг 2х20" },
            new Exercise { Name = "Присед штанга на груди 2х10; 2х8; 2х6" },
            new Exercise { Name = "Передняя поверхность бедра с уменьшением веса 8-10-12-15" },
            new Exercise { Name = "М.тяга со штангой 4х8" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan117 = new Plan {
                    CrossDBId = "l30",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Скакалка 250" },
            new Exercise { Name = "Приседания со штангой на плечах 15-2х8-2х6" },
            new Exercise { Name = "М.тяга штанга с пола 15-3х8-6" },
            new Exercise { Name = "Шаги-фермера с гантелями 3х8" },
            new Exercise { Name = "Икры, планка, вис, пресс" },
        }
                };

                Plan plan118 = new Plan {
                    CrossDBId = "l31",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Задняя поверхность бедра с увеличением веса 15-12-10-8" },
            new Exercise { Name = "Приседания с гирей 22 кг (максимально низко как можете)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "М.тяга с гирей 28 кг" },
            new Exercise { Name = "25+25 3 серии" },
            new Exercise { Name = "Икры с гантелями 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan119 = new Plan {
                    CrossDBId = "l32",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х15" },
            new Exercise { Name = "Задняя поверхность бедра с увеличением веса 15-12-10-8" },
            new Exercise { Name = "Приседания Зерчера 15-12-10-8-6" },
            new Exercise { Name = "М.тяга со штангой-//-//-" },
            new Exercise { Name = "Икры с гантелями 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan120 = new Plan {
                    CrossDBId = "l33",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Присед штанга на груди 8-8-10-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Передняя поверхность бедра 4х15 с рабочим весом" },
            new Exercise { Name = "Выпады со штангой на месте без смены ног 3х12" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan121 = new Plan {
                    CrossDBId = "l34",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х15" },
            new Exercise { Name = "Присед Зерчера 6-8-10-10-12-15 с уменьшением веса" },
            new Exercise { Name = "Шаги-фермера с гантелями 3х8 с большим весом" },
            new Exercise { Name = "Передняя поверхность бедра одной ногой 4х8 без отдыха" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan122 = new Plan {
                    CrossDBId = "l35",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Шаги-фермера с гантелями с уменьшением веса" },
            new Exercise { Name = "6-8-10-12-15" },
            new Exercise { Name = "М.тяга со штангой 15-12-10-8-8" },
            new Exercise { Name = "Передняя поверхность бедра 3х15" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan123 = new Plan {
                    CrossDBId = "l36",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Велосипед 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Жим ногами 15-4х8-15" },
            new Exercise { Name = "М.тяга со штангой-//-//-" },
            new Exercise { Name = "Передняя поверхность бедра 4х15" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan124 = new Plan {
                    CrossDBId = "l37",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 3х10" },
            new Exercise { Name = "Шаги-фермера со штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Приседания со штангой" },
            new Exercise { Name = "чередуем шаг + 2 приседа 3х10 шагов" },
            new Exercise { Name = "М.тяга со штангой 15-12-10-8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 18" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пресс на коврике (велосипед) 25" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan125 = new Plan {
                    CrossDBId = "l38",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пресс на брусьях 20" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Жим ногами 25-20-15-12-10-8 с увеличением веса" },
            new Exercise { Name = "Шаги-фермера с гантелями 5-7-9 кг х 18-15-12" },
            new Exercise { Name = "Икры в тренажёре 3хmax" },
            new Exercise { Name = "Прогибы в боковой планке 3х10 на каждую сторону" },
        }
                };

                Plan plan126 = new Plan {
                    CrossDBId = "l39",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Передняя поверхность бедра 3х15 с весом выше среднего" },
            new Exercise { Name = "Присед со штангой 15-12-10-8-6 с увеличением веса" },
            new Exercise { Name = "М.тяга штанги с пола 4х8" },
            new Exercise { Name = "Икры в тренажере 3х25" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan127 = new Plan {
                    CrossDBId = "l40",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия 2х18" },
            new Exercise { Name = "Шаги-фермера со штангой (средний темный гриф из угла) 12-10-8-8" },
            new Exercise { Name = "Мостик на одной ноге с упором на лежак 3х12(15)" },
            new Exercise { Name = "Передняя поверхность бедра с увеличением веса 4х15" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan128 = new Plan {
                    CrossDBId = "l41",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия 2х20" },
            new Exercise { Name = "Жим ногами 25-20-18-15-12-10 с увеличением веса" },
            new Exercise { Name = "Шаги-фермера с тяжелыми гантелями 3х12" },
            new Exercise { Name = "Передняя п-ов бедра начиная с максимального веса и снижая его 8-10-12-15-18-20-25" },
            new Exercise { Name = "Икры в тренажёре 3хмакс" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan129 = new Plan {
                    CrossDBId = "l42",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Приседания со штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "М.тяга с гирей 32 кг" },
            new Exercise { Name = "15-12-10-8 + 20" },
            new Exercise { Name = "Передняя п-ов бедра с уменьшением веса 8-10-12-15-18-20" },
            new Exercise { Name = "Икры в тренажёре 3хmax" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan130 = new Plan {
                    CrossDBId = "l43",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия горизонтальная блин 5 кг со статической задержкой 15 + 10’’ х 3" },
            new Exercise { Name = "Приседания со штангой на стул 18-15-12-10-8-8-5" },
            new Exercise { Name = "Шаги-фермера с гантелями 3х8(10)" },
            new Exercise { Name = "М.тяга со штангой 3х15 со средним весом" },
            new Exercise { Name = "Икры 3хmax" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan131 = new Plan {
                    CrossDBId = "l44",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Жим ногами 15-12-10-3х8" },
            new Exercise { Name = "Выпады со штангой без смены ног поочерёдно 8/10/12/15 (допускается делить вес. к примеру, 8 на 4-4-4-4 поочерёдно, 10 на 5-5-5-5 и т.д.)" },
            new Exercise { Name = "Передняя поверхность бедра с уменьшением веса 8-10-12-2х15" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan132 = new Plan {
                    CrossDBId = "l45",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Передняя поверхность бедра с увеличением веса 20-18-15-12-10-8" },
            new Exercise { Name = "Шаги-фермера со штангой 15-12-10-8-6 с увеличением веса" },
            new Exercise { Name = "Жим ногами 3х15 с хорошим рабочим весом" },
            new Exercise { Name = "Икры 3хмакс" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan133 = new Plan {
                    CrossDBId = "l46",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия горизонтальная блин 5 кг 3х18" },
            new Exercise { Name = "Приседания со штангой с уменьшением веса 2-4-6-8-10" },
            new Exercise { Name = "Выпады со штангой без смены ног 8-10-12-15 (можно делать разбивку на 4-5-6-3 по 5 каждый из подходов)" },
            new Exercise { Name = "Передняя поверхность бедра 3х15" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                Plan plan134 = new Plan {
                    CrossDBId = "l47",
                    Category = "Legs",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15" },
            new Exercise { Name = "Гиперэкстензия блин 8 кг 3х18" },
            new Exercise { Name = "Присед с гантелью 25(3х15)-20(18)-15(20) кг под пяточки блин" },
            new Exercise { Name = "Выпады с гантелями на месте шаг назад попеременно 3х15" },
            new Exercise { Name = "Мостик с упором туловища на лежак 3х15" },
            new Exercise { Name = "Икры, пресс, планка" },
        }
                };

                db.Plans.AddRange(plan88, plan89, plan90, plan91, plan92, plan93, plan94, plan95,
                    plan96, plan97, plan98, plan99, plan100, plan101, plan102, plan103, plan104,
                    plan105, plan106, plan107, plan108, plan109, plan110, plan111, plan112, plan113,
                    plan114, plan115, plan116, plan117, plan118, plan119, plan120, plan121, plan122,
                    plan123, plan124, plan125, plan126, plan127, plan128, plan129, plan130, plan131,
                    plan132, plan133, plan134);
                db.SaveChanges();

                Plan plan135 = new Plan {
                    CrossDBId = "c1",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разминка плеч, коленок" },
            new Exercise { Name = "Гиперэкстензия 25" },
            new Exercise { Name = "Жим гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга Т-грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Выпады в Смитте" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя одновременно (25-20-15-10)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок (-//-//-)" },
            new Exercise { Name = "всё остальное 15;12;10;8" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс на перекладине 4х15; планка 1’" },
        }
                };

                Plan plan136 = new Plan {
                    CrossDBId = "c2",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга вертикальная к груди широким хватом 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Присед с гирей 16 кг 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя попеременно 5(6) кг 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от лежака 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пресс на коврике 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "3 круга" },
        }
                };

                Plan plan137 = new Plan {
                    CrossDBId = "c3",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разминка коленок 2х15, плеч с гантелями 2 кг 10-10-10" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Жим гантель лёжа 15-12-10 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя 12-10-8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга Т-грифа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Шаги-фермера с гантелями 15-12-10 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя одновременно (один вес на все подходы)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелью стоя (-//-//-)" },
            new Exercise { Name = "Круги по 10;12;15 поповторений" },
            new Exercise { Name = "Пресс на коврике локоть к коленке наискосок 4х15 в каждую сторону; Планка 1,5’" },
        }
                };

                Plan plan138 = new Plan {
                    CrossDBId = "c4",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 3 кг 10-10-10" },
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия блин 5-8-10 кг х 25-20-15" },
            new Exercise { Name = "Жим гантель стоя 6 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 4 кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Подтягивание широким хватом" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола узкий хват локти вдоль тела" },
            new Exercise { Name = "10+10+(?) сколько каждый сможет (можно с резиной)+15" },
            new Exercise { Name = "4 серии" },
            new Exercise { Name = "Трицепс с гантелью стоя 8(10) кг" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс-кривуха сидя с большим весом" },
            new Exercise { Name = "15+15 3 круга" },
            new Exercise { Name = "Пресс на коврике 4х20 40’’ отдыха" },
            new Exercise { Name = "Планка 1’" },
        }
                };

                Plan plan139 = new Plan {
                    CrossDBId = "c5",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель стоя 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от брусьев 10" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Подтягивание на перекладине с резиной 10" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола локти вдоль туловища 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя одновременно 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "4 круга" },
        }
                };

                Plan plan140 = new Plan {
                    CrossDBId = "c6",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка стоя полная амплитуда 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина широким хватом 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Приседания в Смите 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа 25-20-15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с прямым грифом (20-25 кг) 25-20-15" },
            new Exercise { Name = "Пресс, планка" },
            new Exercise { Name = "3 круга" },
        }
                };

                Plan plan141 = new Plan {
                    CrossDBId = "c7",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Скакалка 150" },
            new Exercise { Name = "Гиперэкстензия 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Велосипед 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Подъёмы ног 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "Отжимание на брусьях 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Подтягивание на перекладине с резиной широким хватом 15-12-10-8 (можно 12-10-8-8)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола 25-20-15-15" },
            new Exercise { Name = "Бицепс с прямой штангой 10" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя одновременно по 5 раз на руку 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс с гантелями лёжа 15" },
            new Exercise { Name = "3 круга" },
        }
                };

                Plan plan142 = new Plan {
                    CrossDBId = "c8",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель стоя 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание на брусьях max" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина хват сверху средний 10(8)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола локти вдоль туловища 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя попеременно 12 (берите большой вес)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "4 круга" },
        }
                };

                Plan plan143 = new Plan {
                    CrossDBId = "c9",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа поочерёдно по 3 раза на руку 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Протяжка с кривой штангой 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга вертикальная к груди обратным хватом 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Молот стоя одновременно+поочерёдно 10+5" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Кисти штанга сидя 3хмах" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan144 = new Plan {
                    CrossDBId = "c11",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя чередуем по 3 раза 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина широким хватом 10" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Тяга Т-грифа 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя поочерёдно 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan145 = new Plan {
                    CrossDBId = "c12",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим гантель лёжа на наклонной скамье 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя попеременно 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина с резиной хват сверху широкий 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимание от пола локти вдоль туловища 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Приседания с гирей 22 кг 20" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя поочерёдно 10+5" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от лежака 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Велосипед 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "3 круга" },
        }
                };

                Plan plan146 = new Plan {
                    CrossDBId = "c13",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Гиперэкстензия (все круги по 15 раз)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель лёжа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Жим гантель стоя 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина с резиной (все круги по 6 раз, хват широкий)" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Присед с гирей (16-18-20 кг) 25-20-15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Бицепс с гантелями стоя (можно заменить на штангу) 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Франц.жим стоя с одной гантелью 18" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пресс на коврике 25" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Планка 1’" },
            new Exercise { Name = "3 круга" },
        }
                };

                Plan plan147 = new Plan {
                    CrossDBId = "c14",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 10-10-10 (жим-разводка-наклоны)" },
            new Exercise { Name = "Протяжка с кривой штангой 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Перекладина с резиной 8" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Отжимания от пола с блином 5(8) кг 15" },
            new Exercise { Name = "4 круга" },
            new Exercise { Name = "Молот с одной гантелью в наклоне" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс-блок" },
            new Exercise { Name = "12+15 х 3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                Plan plan148 = new Plan {
                    CrossDBId = "c15",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Разминка плеч с гантелями 2 кг 15-15-15" },
            new Exercise { Name = "Протяжка с гантелью + Жим гантели 15+15 х 3 на каждую руку" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Разводка гантель стоя полная амплитуда" },
            new Exercise { Name = "10+10 3 круга, чередуем по разу" },
            new Exercise { Name = "Тяга вертикальная за голову с уменьшением веса 8-10-12-15" },
            new Exercise { Name = "Бицепс с кривой штангой 5-5-5" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Горизонтальная гиперэкстензия блин 5 кг 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Обведение гири ногами 10" },
            new Exercise { Name = "3 круга без отдыха" },
        }
                };

                Plan plan149 = new Plan {
                    CrossDBId = "c16",
                    Category = "Circuit",
                    Exercises = {
            new Exercise { Name = "Жим штанги лёжа в Смите 15-12-10-8-8" },
            new Exercise { Name = "Разводка гантель лёжа" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Пуловер поперек скамьи" },
            new Exercise { Name = "8+12 3 круга" },
            new Exercise { Name = "Разводка гантель стоя" },
            new Exercise { Name = "+" },
            new Exercise { Name = "-//-//- Разводка гантель стоя полная амплитуда" },
            new Exercise { Name = "8+8 (чередуем по разу) 3 круга" },
            new Exercise { Name = "Бицепс-кривуха хват сверху 12" },
            new Exercise { Name = "+" },
            new Exercise { Name = "Трицепс от грифа 15" },
            new Exercise { Name = "3 круга" },
            new Exercise { Name = "Пресс, планка" },
        }
                };

                db.Plans.AddRange(plan135, plan136, plan137, plan138, plan139, plan140,
                    plan141, plan142, plan143, plan144, plan145, plan146, plan147, plan148,
                    plan149);
                db.SaveChanges();
            }
        }



        public async Task<IActionResult> Index() {
            var user = await _userManager.GetUserAsync(User);
            var plans = db.Plans.Include(e => e.Exercises).ToListAsync();
            var model = new Tuple<IEnumerable<TrainingPlansWA.Models.Plan>, TrainingPlansWA.Areas.Identity.Data.UserModel>(await plans, user);
            return View(model);

            //return View(await plans);
            //return View(await db.Plans.ToListAsync());
        }

        /* [HttpPost]
         public async Task<IActionResult> Create(User user) {
             db.Users.Add(user);
             await db.SaveChangesAsync();
             return RedirectToAction("Index");
         }*/
    }
}
