using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Data;
using System;
using System.Linq;
using Bogus;


namespace MyPortfolio.Models
{
    public static class SeedData
    {

        private static List<Article> FakeArticles(int count)
        {
            var articleFaker = new Faker<Article>()
                .RuleFor(m => m.Title, f => f.Lorem.Sentence())
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.Auther, "Tom Woodward");
            return articleFaker.Generate(count);
        }

        private static List<GuestBook> FakeGuestBook(int count)
        {
            var guestBookFaker = new Faker<GuestBook>()
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName);
            return guestBookFaker.Generate(count);
        }
        private static List<Skill> FakeSkill(int count)
        {
            var skillFaker = new Faker<Skill>()
                .RuleFor(m => m.Name, f => f.Person.FullName)
                .RuleFor(m => m.Description, f => f.Lorem.Paragraph(4))
                .RuleFor(m => m.Percentage, f => f.Random.Number(1, 100));
            return skillFaker.Generate(count);
        }

        private static List<Message> FakeMessages(int count)

        {

            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);
        }

        private static List<Portfolio> FakePortfolios(int count)
        {

            var portfolioFaker = new Faker<Portfolio>()
                .RuleFor(m => m.Title, f => f.Lorem.Sentence())
                .RuleFor(m => m.Description, f => f.Lorem.Paragraph(4))
                .RuleFor(m => m.Pic, f => "/images/Mines" + f.Random.Number(1, 6) + ".jpg")
                .RuleFor(m => m.Slug, f=>f.Internet.Url());
            return portfolioFaker.Generate(count);
        }



        private static Article[] addArticle()
        {
            
            return new Article[] {

                new Article
                {
                Title = "Memorial track’s making recorded",
                Body = "Building an ambitious bike track in one of New Zealand’s most remote and inhospitable regions was not enough of a challenge for a Queenstown videographer. After a year of working on the $12million Pike 29 Memorial Track, Tom Woodward decided the efforts of the team should be documented.",
                Auther = "Otago Daily Times",
                Slug = "https://www.odt.co.nz/regions/west-coast/memorial-track%E2%80%99s-making-recorded",
                CreatedAt = DateTime.Now
                },
                new Article{
                Title = "Track workers’ resilience and skill ‘massive’",
                Auther = "Otago Daily Times",
                Body = "Crews working under Nelmac’s Tom Woodward have finished 5km of track north of Moonlight Tops Hut and are still hard at work on the 11km Pike 29 Memorial Track, which drops off the main track north down to what will be the Pike River Mine Interpretation Centre.",
                Slug = "https://www.odt.co.nz/regions/west-coast/track-workers%E2%80%99-resilience-and-skill-%E2%80%98massive%E2%80%99",
                CreatedAt = DateTime.Now
                },
                new Article{
                Title = "Adventure-seeker snowboards through city streets to buy some milk after a massive dumping of snow",
                Body = "A New Zealand man has filmed the moment he snowboarded through the streets after an unexpected dumping of snow.Footage showed Tom Woodward taking his board for a ride from the driveway of his Fernhill home in Queenstown, on Monday.",
                Auther = "Daily Mail",
                Slug = "https://www.dailymail.co.uk/news/article-8779809/Adventure-seeker-snowboards-house-Queenstown-massive-dumping-snow-New-Zealand.html",
                CreatedAt = DateTime.Now
                },
                new Article{
                Title = "Snow dump a welcome start for school holiday skiers and snowboarders",
                Body = "Queenstown man Tom Woodward, who lives in the elevated suburb of Fernhill, said people were cheering as he snowboarded past buses and stuck cars this morning. Woodward had planned to head up to The Remarkables to take advantage of the fresh powder, but when he saw it was closed, he had to adjust his plans.He said the snow was “really belting down” about 8am, building up to about 30 centimetres high in places, though it was slightly lower on the warm roads.",
                Auther = "Stuff.co.nz",
                Slug = "https://www.stuff.co.nz/travel/experiences/snow-ski-holidays/300117901/snow-dump-a-welcome-start-for-school-holiday-skiers-and-snowboarders",
                CreatedAt = DateTime.Now
                },
                new Article{
                Title = "Tales from the Paparoa",
                Body = "Building the Pike 29 Memorial Track was a unique project. Deep in the mountains on the West Coast of the South Island, and with helicopter-only access, we spent almost three years dragging machinery through the mud and blasting through rock faces to create New Zealand’s 10th Great Walk and first Great Ride.",
                Auther = "spokemagazine.com",
                Slug = "https://spokemagazine.com/story-tales-from-the-paparoa/",
                CreatedAt = DateTime.Now
                },
                new Article{
                Title = "BUILDING THE PIKE29 MEMORIAL TRACK",
                Body = "Tom Woodward and his crew spent three years toiling in often extreme conditions  to construct the Pike29 Memorial Track as part of the newly minted DOC Paparoa Track. He has captured the story in a ripping short film that recently picked up a gong at the NZ Mountain Film Festival.",
                Auther = "groundeffect.co.nz",
                Slug = "https://www.groundeffect.co.nz/",
                CreatedAt = DateTime.Now
                },
            };
        }



        private static Experience[] addExperience()
        {

            return new Experience[] { 
                new Experience
                {
                    Title = "Trail Builder",
                    Location = "Patagonia, Chile",
                    Duration = "2010-2012",
                    description = "I worked in a remote location in the Patagonian mountians building a mountian bike trail network"
                },
                new Experience
                {
                    Title = "Trail Builder",
                    Location = "Alentejo, Portugal",
                    Duration = "2012-2013",
                    description = "I worked in a rural location in the Portugal building a mountian bike trail network"

                },
                new Experience
                {
                    Title = "Scaffolder",
                    Location = "Pilbara Region, Western Australia",
                    Duration = "2014-2017",
                    description = "I worked Fly-In-Fly-Out and mine sites in the Australian Outback"

                },
                new Experience
                {
                    Title = "Trail Builder",
                    Location = "Paparoa Mountains",
                    Duration = "2017 - 2020",
                    description = "I worked in a remote part of the West Coast building the Pike29 Moutain Bike Track"
                }
            };
        }

        private static Portfolio[] addPortfolio()
        {
            return new Portfolio[] { new Portfolio
                {
                Title = "(Private Link) 3 years in the Australian mines! (What it's really like) | FIFO from Bali",
                Description = "The Pike 29 Memorial Track was built as a living memorial to the men who died in the 2010 Pike mining disaster. It was sculpted into the landscape by passionate mountain bikers and track builders and is a world-class and first-of-its-kind mountain bike track which doubles and New Zealand’s 10th Great Walk.This video shows some of the exploits of the team who built it called the Bush Walruses.MTB track designer and digger operator Milty Coultas, explosives specialist and track shaper Tom Woodward, and tree fellers Logan and Felix.We cut the track through the bush over three long years while exposed, battered and frost bitten by the elements on the West Coast the most extreme construction site that any of us had worked at.This video featured in the 2020 New Zealand Mountain Film Festival.",
                Pic = "/images/3YearsInTheMines.jpg",
                Slug = "https://youtu.be/wlfNcpRq-Io"
                },
                new Portfolio{
                Title = "Building a $12MD Bike Trail | The Pike 29 Track",
                Description = "Many New Zealanders have made their way to Australia chasing the mining boom. In the state of W.A Thousands of guys work Fly in Fly out jobs in outback mines. Due to the vast distances to the nearest cities, an entire industry has developed of FIFO workers who have relocated permanently the tropical paradise of Bali, and fly in out to the mines from there. This video chronicles 3 years of one Kiwi working in the mines while living in Bali.It attempts to be a window into that world and show the pros and cons of the lifestyle, at once dangerous, exciting and dull.",
                Pic = "/images/Pike29Track.jpg",
                Slug = "https://youtu.be/U7Xlyfr0ud0"
                },
                new Portfolio{
                Title = "Journey to the South Pacific | Cook Islands & New Zealand",
                Description = "This video shows some of the highlights of the South Pacific islands of New Zealand's South Island and the Cook Islands.Starting in Queenstown New Zealand we planned our road trip around New Zealand's South Island, and then flew to the tropical islands of Rarotonga and Aitutaki in the Cook islands.Aitutaki had some of the clearest water that surrounds beautiful palm clad islands.",
                Pic = "/images/CookIslands.jpg",
                Slug = "https://youtu.be/c15uqtiS52M"
                },
        };
        }



        private static Skill[] addSkill()
        {
            return new Skill[]
            {
                new Skill
                {
                    Name = "Final Cut Pro",
                    Description = "Many years use of Final Cut Pro software to produce videos that have been features in the New Zealand Mountian Film Festival",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Explosive Use",
                    Description = "Two years using Power Gel, ammonium nitrate explosives for above ground opereations during the construction of the Pike 29 Memorial Track",
                    Percentage = 95
                },
                new Skill
                {
                    Name = "Spanish Language",
                    Description = "Proficient in both spoken and written Spanish language, at medium proficiency with Portuguese",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Laravel",
                    Description = "Basic Laravel framework skills developed from SIT level 6 web applications, and own project building Activity Dock",
                    Percentage = 05
                },
                new Skill
                {
                    Name = ".NET",
                    Description = "Basic level of working with the .Net framework at SIT Level 7. The first time that I have used it is to make this portfolio",
                    Percentage = 02
                },
                new Skill
                {
                    Name = "C#",
                    Description = "Learner with C#, I did a on C# at level 6. It was less intuitive than JavaScrip but I liked in nonetheless",
                    Percentage = 02
                },
                new Skill
                {
                    Name = "JavaScript",
                    Description = "Learner with JavaScript. I did one level 5 papaer on JavaScript for basic programming. I liked the language and it mostly made sense",
                    Percentage = 02
                },
                new Skill
                {
                    Name = "HTML/CSS",
                    Description = "Learner with HTML/CSS, during level 5 I had to complete a basic HTML/CSS website. After that I have used it a few times with laravel and .NET",
                    Percentage = 02
                },
            };
        }



        private static About[] addAbout()
        {
            return new About[]
            {
                new About
                {
                    Pic = "/images/AboutPageImages/01.jpg",
                    Slug = "https://www.instagram.com/p/CbpH61XJL3J/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/2.jpg",
                    Slug = "https://www.instagram.com/p/CYY_i4xtLDR/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/3.jpg",
                    Slug = "https://www.instagram.com/p/CVjJbwOhkiX/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/4.jpg",
                    Slug = "https://www.instagram.com/p/CVUgCrUJgpn/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/5.jpg",
                    Slug = "https://www.instagram.com/p/CTaRPd2BkM2/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/6.jpg",
                    Slug = "https://www.instagram.com/p/CTaRPd2BkM2/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/7.jpg",
                    Slug = "https://www.instagram.com/p/CSLpOxnpJQc/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/8.jpg",
                    Slug = "https://www.instagram.com/p/CSLpOxnpJQc/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/9.jpg",
                    Slug = "https://www.instagram.com/p/CRV0_2FtPCK/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/10.jpg",
                    Slug = "https://www.instagram.com/p/COgcVrRth7g/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/11.jpg",
                    Slug = "https://www.instagram.com/p/CLi56EVgnj9/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/12.jpg",
                    Slug = "https://www.instagram.com/p/CLC9Hd2AoYI/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/13.jpg",
                    Slug = "https://www.instagram.com/p/CKDRt2iAH0b/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/14.jpg",
                    Slug = "https://www.instagram.com/p/CJ7WiU9Ax2d/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/15.jpg",
                    Slug = "https://www.instagram.com/p/CJ1wlbbgz7f/?utm_source=ig_web_copy_link"
                },
                new About
                {
                    Pic = "/images/AboutPageImages/16.jpg",
                    Slug = "https://www.instagram.com/p/CJsHeMGg9Mv/?utm_source=ig_web_copy_link"
                },
            };
        }



        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyPortfolioContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyPortfolioContext>>()))
            {
                if (!context.Experience.Any())
                    context.Experience.AddRange(addExperience());

                if (!context.About.Any())
                    context.About.AddRange(addAbout());

                if (!context.Message.Any())
                    context.Message.AddRange(FakeMessages(30));

                if (!context.GuestBook.Any())
                    context.GuestBook.AddRange(FakeGuestBook(10));

                if (!context.Portfolio.Any()) {                                    
                    context.Portfolio.AddRange(addPortfolio());
                    context.Portfolio.AddRange(FakePortfolios(06));
                }
                if (!context.Article.Any()) {
                    context.Article.AddRange(FakeArticles(20));
                    context.Article.AddRange(addArticle());
                }
                if (!context.Skill.Any()) {
                    context.Skill.AddRange(addSkill());
                    context.Skill.AddRange(FakeSkill(30));
                }
                context.SaveChanges();
            }
        }
    }
}