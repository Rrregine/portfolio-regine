using Portfolio_Regine.Models;

namespace Portfolio_Regine.Helpers
{
    public static class Translations
    {
        // Store the current language, default to English
        private static string _currentLanguage = "en";

        // Set the language (e.g., 'en' for English, 'fr' for French, etc.)
        public static void SetLanguage(string lang)
        {
            _currentLanguage = lang;
        }

        // Translations dictionary for different languages
        private static readonly Dictionary<string, Dictionary<string, string>> _translations = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "en", new Dictionary<string, string>
            {
                { "AuthorName", "Regine Wang" },
                { "JobTitle", "Full-stack Developer" },
                { "AboutMe", "About Me" },
                { "WhatImGoodAt", "What I'm Good At" },
                { "MyWork", "My Work" },
                { "Testimonials", "Testimonials" },
                { "AboutMeHeading", "About Me" },
            { "AboutMeContent1", "Hello! My name is Regine Wang." },
            { "AboutMeContent2", "I’m a passionate third-year Computer Science student at Champlain College, graduating in 2025." },
            { "AboutMeContent3", "I’ve always been intrigued by technology and how it can improve the world around us." },
            { "AboutMeContent4", "I have a strong foundation in software development, with experience working on full-stack web development projects and learning new technologies." },
            { "SkillsHeading", "Skilled in Full-stack Web Development" },
            { "SkillsContent1", "With proficiency in languages such as Java, JavaScript, C#, and Python," },
            { "SkillsContent2", "my experience includes working with frameworks like Spring Boot, React, and ASP.NET MVC." },
            { "SkillsContent3", "I am also comfortable with databases such as MongoDB, MySQL, and PostgreSQL." },
            { "SkillsCVText", "Here is my CV!" },
                {"DownloadCV", "Download CV" },
                { "FreeTimeHeading", "In My Free Time..." },
            { "FreeTimeContent1", "I enjoy gardening and writing, which allow me to express creativity and unwind." },
            { "FreeTimeContent2", "Gardening helps me connect with nature, while writing enables me to explore new ideas and improve my communication skills." },
            { "FreeTimeContent3", "Both hobbies provide a perfect balance to my tech-focused work." },
            { "FreeTimeContactText", "Do you have the same hobby as me? Don't hesitate to contact me!" },
            { "FreeTimeButton", "Contact Me" },
            { "WhatImGoodAtHeading", "What I’m good at?" },
            { "WhatImGoodAtIntro", "I have developed a strong foundation in IT and software development through academic projects and hands-on experience. Here are four key skills that define my expertise:" },
            { "Skill1Title", "Full-Stack Development" },
            { "Skill1Description", "Proficient in front-end and back-end development using technologies like Java, JavaScript, C#, React, ASP.NET MVC, and Spring Boot to build scalable and efficient applications." },
            { "Skill2Title", "System Design" },
            { "Skill2Description", "Experienced in designing and implementing robust software architectures with microservices and strong understanding of databases like SQLite and MySQL." },
            { "Skill3Title", "Team Collaboration" },
            { "Skill3Description", "Skilled in Agile Scrum methodology, collaborating effectively with cross-functional teams using GitHub, Jira, and Figma to deliver high-quality software solutions." },
            { "Skill4Title", "Communication" },
            { "Skill4Description", "Strong communication skills with experience in leadership roles, such as Product Owner in large-scale projects, ensuring smooth project execution and team coordination." },
            { "MyWorkHeading", "My Work" },
            { "HereAreSomeProjects", "Here are some of the projects I’ve worked on, showcasing my skills in full-stack development, system design, and collaboration. Each project reflects my ability to build scalable applications, work in teams, and apply industry best practices. Check all these projects on my GitHub!" },
            { "All", "all" },
            { "Website", "website" },
            { "MobileApp", "mobile app" },
            { "Game", "game" },

             // Newly added translations
            { "LeaveYourCommentsHere", "Leave your comments here" },
            { "WhatDoYouThinkAboutMyWork", "What do you think about my work?" },
            { "YourName", "Your name" },
            { "YourEmail", "Your email" },
            { "Title", "Title" },
            { "YourMessage", "Your message" },
            { "Submit", "Submit" },
            { "TestimonialsHeading", "Testimonials" },
                {"TestimonialSuccess", "Your testimonial has been submitted and is awaiting approval!" },
                {"ViewDetails", "View Details" },
            }
        },
        {
            "fr", new Dictionary<string, string>
            {
                { "AuthorName", "Regine Wang" },
                { "JobTitle", "Développeuse Full-stack" },
                { "AboutMe", "À propos de moi" },
                { "WhatImGoodAt", "Ce que je sais faire" },
            { "MyWork", "Mon travail" },
            { "Testimonials", "Témoignages" },
            { "AboutMeHeading", "À propos de moi" },
            { "AboutMeContent1", "Bonjour! Je m'appelle Regine Wang." },
            { "AboutMeContent2", "Je suis une étudiante passionnée en troisième année d'informatique au Champlain College, diplômée en 2025." },
            { "AboutMeContent3", "J'ai toujours été intriguée par la technologie et comment elle peut améliorer le monde autour de nous." },
            { "AboutMeContent4", "J'ai une solide base en développement logiciel, avec de l'expérience sur des projets de développement web full-stack et l'apprentissage de nouvelles technologies." },
             { "SkillsHeading", "Compétences en développement web full-stack" },
            { "SkillsContent1", "Avec une maîtrise des langages tels que Java, JavaScript, C#, et Python," },
            { "SkillsContent2", "mon expérience inclut le travail avec des frameworks comme Spring Boot, React, et ASP.NET MVC." },
            { "SkillsContent3", "Je suis également à l'aise avec des bases de données telles que MongoDB, MySQL et PostgreSQL." },
            { "SkillsCVText", "Voici mon CV!" },
                {"DownloadCV", "Télécharger CV" },
                { "FreeTimeHeading", "Dans mon temps libre..." },
            { "FreeTimeContent1", "J'aime le jardinage et l'écriture, ce qui me permet d'exprimer ma créativité et de me détendre." },
            { "FreeTimeContent2", "Le jardinage m'aide à me connecter à la nature, tandis que l'écriture me permet d'explorer de nouvelles idées et d'améliorer mes compétences en communication." },
            { "FreeTimeContent3", "Les deux hobbies offrent un parfait équilibre avec mon travail axé sur la technologie." },
            { "FreeTimeContactText", "Avez-vous le même hobby que moi ? N'hésitez pas à me contacter !" },
            { "FreeTimeButton", "Contactez-moi" },
                         { "WhatImGoodAtHeading", "Ce que je sais faire ?" },
            { "WhatImGoodAtIntro", "J'ai développé une solide base en informatique et en développement logiciel à travers des projets académiques et des expériences pratiques. Voici quatre compétences clés qui définissent mon expertise :" },
            { "Skill1Title", "Développement Full-Stack" },
            { "Skill1Description", "Compétent en développement front-end et back-end avec des technologies telles que Java, JavaScript, C#, React, ASP.NET MVC et Spring Boot pour créer des applications évolutives et efficaces." },
            { "Skill2Title", "Conception de Systèmes" },
            { "Skill2Description", "Expérience dans la conception et la mise en œuvre d'architectures logicielles robustes utilisant des microservices et une bonne compréhension des bases de données comme SQLite et MySQL." },
            { "Skill3Title", "Collaboration en équipe" },
            { "Skill3Description", "Compétent en méthodologie Agile Scrum, collaborant efficacement avec des équipes interfonctionnelles en utilisant GitHub, Jira et Figma pour livrer des solutions logicielles de haute qualité." },
            { "Skill4Title", "Communication" },
            { "Skill4Description", "Excellentes compétences en communication avec une expérience dans des rôles de leadership comme Product Owner dans des projets, garantissant une exécution fluide des projets et une coordination de l'équipe." },
            { "MyWorkHeading", "Mon travail" },
            { "HereAreSomeProjects", "Voici quelques projets sur lesquels j'ai travaillé, mettant en valeur mes compétences en développement full-stack, conception de systèmes et collaboration. Consultez mon profile GitHub pour voir mes projects!" },
            { "All", "tout" },
            { "Website", "site web" },
            { "MobileApp", "application mobile" },
            { "Game", "jeu vidéo" },
                {"TestimonialSuccess", "Votre témoignage a été soumis et est en attente d'approbation !" },

            // Newly added translations
            { "LeaveYourCommentsHere", "Laissez vos commentaires ici" },
            { "WhatDoYouThinkAboutMyWork", "Que pensez-vous de mon travail ?" },
            { "YourName", "Votre nom" },
            { "YourEmail", "Votre email" },
            { "Title", "Titre" },
            { "YourMessage", "Votre message" },
            { "Submit", "Soumettre" },
            { "TestimonialsHeading", "Témoignages" },
            {"ViewDetails", "En Savoir Plus" },
            }
        }
    };

        // Method to get the translated value for a given key
        public static string Translate(string key)
        {
            return _translations[_currentLanguage].TryGetValue(key, out var value) ? value : key;
        }
    }

}
