using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;

class Program
{
    private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
    private static string userName;

    static async Task Main()
    {
        synthesizer.SelectVoice("Microsoft David Desktop");
        synthesizer.Rate = 2;

        await SpeakAsync("Yo! What is good! I am CyberGuard, your cybersecurity buddy. I am here to vibe with you on staying safe in the digital streets. What do they call you?");

        DisplayASCIIArt();
        await InteractWithUser();
    }

    static void DisplayASCIIArt()
    {
        string asciiArt = @"
+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
   ______      __              ______                     __
  / ____/_  __/ /_  ___  _____/ ____/_  ______ __________/ /
 / /   / / / / __ \/ _ \/ ___/ / __/ / / / __ `/ ___/ __  /
/ /___/ /_/ / /_/ /  __/ /  / /_/ / /_/ / /_/ / /  / /_/ /
\____/\__, /_.___/\___/_/   \____/\__,_/\__,_/_/   \__,_/
     /____/

         [  S H I E L D I N G   Y O U R   D I G I T A L   W O R L D  ]

    .------.   .------.   .------.   .------.   .------.
    | >_   |   | [::] |   |  /\  |   | (()) |   | ###  |
    | cmd  |   | net  |   | sec  |   | wifi |   | enc  |
    '------'   '------'   '------'   '------'   '------'
         |_________|_________|_________|_________|
                         [ ONLINE ]
+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    static async Task InteractWithUser()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("CyberGuard: Ayyyy! I'm CYBERGUARD — your go-to for all things cybersecurity. No cap, we're gonna keep your digital life on lock!");
        Console.ResetColor();

        PrintWithTypingAnimation("\nCyberGuard: Before we dive in, what do they call you? Drop your name below: ");
        userName = Console.ReadLine();

        if (!string.IsNullOrEmpty(userName))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"CyberGuard: Aye {userName}! You stepped into the right place. CyberGuard's got you!");
            await SpeakAsync($"Aye {userName}! You stepped into the right place. Let's get it!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation("CyberGuard: Yo I didn't catch that! Run your name back real quick so we can kick things off!");
            Console.ResetColor();
        }

        await AskHowAreYou();
        await AskQuestions();
    }

    static async Task SpeakAsync(string message)
    {
        await Task.Run(() => synthesizer.SpeakAsync(message));
    }

    static async Task AskHowAreYou()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation($"CyberGuard: Aye {userName}, real talk — how you doing today? What's the vibe?");
        Console.ResetColor();

        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string response = Console.ReadLine();
        Console.ResetColor();

        if (response.ToLower() == "stop" || response.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("CyberGuard: Aight, no stress! Catch you on the flip side — stay safe out there!");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (response.ToLower().Contains("good and you") || response.ToLower().Contains("great and you"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"CyberGuard: Aye that's what I like to hear, {userName}! I'm locked in and ready to chop it up about cyber stuff with you!");
        }
        else if (response.ToLower().Contains("good") || response.ToLower().Contains("great"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"CyberGuard: That's the energy, {userName}! Let's keep that momentum going and talk some cyber game!");
        }
        else if (response.ToLower().Contains("bad") || response.ToLower().Contains("not good"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation($"CyberGuard: Aw man, my bad to hear that {userName}. Let CyberGuard drop some knowledge — might just flip your day around!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintWithTypingAnimation($"CyberGuard: Heard you loud and clear, {userName}. Either way, CyberGuard is in the building — let's talk it up!");
        }

        Console.ResetColor();
    }

    static async Task AskQuestions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("CyberGuard: Aight, what cybersecurity topic you want to chop it up about today?");
        Console.ResetColor();

        PrintWithTypingAnimation("  1. Phishing");
        PrintWithTypingAnimation("  2. Password Security");
        PrintWithTypingAnimation("  3. Two-Factor Authentication");
        PrintWithTypingAnimation("  4. Ransomware");
        PrintWithTypingAnimation("  5. Social Engineering");
        PrintWithTypingAnimation("  6. Safe Internet Browsing");
        PrintWithTypingAnimation("  7. Malware Protection");
        PrintWithTypingAnimation("  8. Cyber Hygiene");

        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string userQuestion = Console.ReadLine().ToLower();
        Console.ResetColor();

        if (userQuestion == "stop" || userQuestion == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("CyberGuard: Peace out! Stay secure and keep your digital life on lock!");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (int.TryParse(userQuestion, out int choice) && choice >= 1 && choice <= 8)
        {
            switch (choice)
            {
                case 1: PhishingResponse(); break;
                case 2: PasswordSafetyResponse(); break;
                case 3: TwoFactorAuthenticationResponse(); break;
                case 4: RansomwareResponse(); break;
                case 5: SocialEngineeringResponse(); break;
                case 6: SafeBrowsingResponse(); break;
                case 7: MalwareResponse(); break;
                case 8: CyberHygieneResponse(); break;
            }
        }
        else
        {
            switch (userQuestion)
            {
                case "phishing": PhishingResponse(); break;
                case "password safety": PasswordSafetyResponse(); break;
                case "two-factor authentication": TwoFactorAuthenticationResponse(); break;
                case "ransomware": RansomwareResponse(); break;
                case "social engineering": SocialEngineeringResponse(); break;
                case "safe browsing": SafeBrowsingResponse(); break;
                case "malware": MalwareResponse(); break;
                case "cyber hygiene": CyberHygieneResponse(); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintWithTypingAnimation("CyberGuard: Yo that one ain't on the list! Pick a number or type one of the topics up there.");
                    Console.ResetColor();
                    break;
            }
        }

        await AskNextStep();
    }

    static async Task AskNextStep()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("CyberGuard: Want to talk about something else? Type 'menu' to see the topics again, or just type one and we keep it moving!");
        Console.ResetColor();
        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string nextStep = Console.ReadLine();
        Console.ResetColor();

        if (nextStep.ToLower() == "stop" || nextStep.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("CyberGuard: Aight we done here! Stay sharp, stay safe — CyberGuard out!");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (nextStep.ToLower() == "menu")
        {
            await AskQuestions();
        }
        else
        {
            switch (nextStep.ToLower())
            {
                case "phishing": PhishingResponse(); break;
                case "password safety": PasswordSafetyResponse(); break;
                case "two-factor authentication": TwoFactorAuthenticationResponse(); break;
                case "ransomware": RansomwareResponse(); break;
                case "social engineering": SocialEngineeringResponse(); break;
                case "safe browsing": SafeBrowsingResponse(); break;
                case "malware": MalwareResponse(); break;
                case "cyber hygiene": CyberHygieneResponse(); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintWithTypingAnimation("CyberGuard: That one ain't in the vault! Stick to the listed topics and we'll keep the convo going.");
                    Console.ResetColor();
                    break;
            }
            await AskNextStep();
        }
    }

    static void PhishingResponse()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        PrintWithTypingAnimation($"CyberGuard: So {userName}, phishing is basically when sketchy people dress up as someone you trust — your bank, your email provider, even your boss — just to trick you into handing over your passwords or personal info.");
        PrintWithTypingAnimation($"CyberGuard: These scams hit through fake emails and dodgy links that look legit. Quick heads up — don't click on stuff you weren't expecting, and always double-check who's actually hitting you up before you share anything.");
        Console.ResetColor();
        AskForFeedback("Phishing");
    }

    static void PasswordSafetyResponse()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation($"CyberGuard: Okay {userName}, real talk — your password is basically the key to your whole digital world. If it's weak, you're leaving the door wide open for anyone. Mix uppercase, lowercase, numbers and symbols to build something tough to crack.");
        PrintWithTypingAnimation($"CyberGuard: And don't reuse the same password across accounts — that's how one leak turns into a whole disaster. Grab a password manager so you don't have to memorise all those strong unique ones.");
        Console.ResetColor();
        AskForFeedback("Password Safety");
    }

    static void TwoFactorAuthenticationResponse()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintWithTypingAnimation($"CyberGuard: Think of 2FA like a second lock on your door, {userName}. Even if someone snags your password, they still can't get in without that second code.");
        PrintWithTypingAnimation($"CyberGuard: Turn on 2FA wherever you can. And if you've got a choice, go with an authenticator app over SMS — text codes can be intercepted but authenticator codes are way harder to grab.");
        Console.ResetColor();
        AskForFeedback("Two-Factor Authentication");
    }

    static void RansomwareResponse()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        PrintWithTypingAnimation($"CyberGuard: Ransomware is straight up digital hostage-taking, {userName}. This nasty software sneaks onto your device, locks up all your files, and demands you pay — usually in crypto — to get them back.");
        PrintWithTypingAnimation($"CyberGuard: Back your stuff up regularly, avoid sketchy links and random downloads, and keep your antivirus fresh. And if it ever hits you — don't pay. Paying doesn't mean you'll actually get your files back.");
        Console.ResetColor();
        AskForFeedback("Ransomware");
    }

    static void SocialEngineeringResponse()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintWithTypingAnimation($"CyberGuard: Social engineering is all mind games, {userName}. Attackers use pressure, fake urgency or false trust to get you to hand over info or do something you normally wouldn't.");
        PrintWithTypingAnimation($"CyberGuard: Whenever something feels off or rushed — even if it looks like it's from someone you know — slow down and verify. One quick call to the real person can save you from a serious headache.");
        Console.ResetColor();
        AskForFeedback("Social Engineering");
    }

    static void SafeBrowsingResponse()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        PrintWithTypingAnimation($"CyberGuard: Safe browsing is about watching your step every time you're online, {userName}. Always check for HTTPS in the address bar — that padlock means your connection is encrypted and your data isn't just floating out there.");
        PrintWithTypingAnimation($"CyberGuard: Keep your browser and plugins updated, skip downloading stuff from random sites, and use a VPN on public Wi-Fi so nobody can snoop on what you're doing.");
        Console.ResetColor();
        AskForFeedback("Safe Browsing");
    }

    static void MalwareResponse()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        PrintWithTypingAnimation($"CyberGuard: Malware is a whole family of bad software built to mess with, spy on, or hijack your device, {userName}. We're talking viruses that wipe your files, spyware watching everything you do, and Trojans sneaking in disguised as normal stuff.");
        PrintWithTypingAnimation($"CyberGuard: Keep a solid antivirus running, never download anything from sources you don't trust, and stay on top of your OS security updates. Those updates patch holes that malware loves to sneak through.");
        Console.ResetColor();
        AskForFeedback("Malware");
    }

    static void CyberHygieneResponse()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintWithTypingAnimation($"CyberGuard: Cyber hygiene is basically your everyday routine for keeping your digital life clean and locked down, {userName} — like brushing your teeth but for your accounts. Update your software, use strong passwords, and keep 2FA on.");
        PrintWithTypingAnimation($"CyberGuard: Small consistent habits stack up into serious protection over time. Staying safe online isn't a one-time thing — it's something you keep doing every day without even thinking about it.");
        Console.ResetColor();
        AskForFeedback("Cyber Hygiene");
    }

    static void AskForFeedback(string topic)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintWithTypingAnimation($"CyberGuard: Aye {userName}, did that hit different on {topic}? Did it make sense?");
        Console.ResetColor();
        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string feedback = Console.ReadLine();
        Console.ResetColor();

        if (feedback.ToLower() == "stop" || feedback.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("CyberGuard: Aight we done here! Stay sharp, stay safe — CyberGuard out!");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (feedback.ToLower().Contains("yes"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("CyberGuard: Let's go! That's what I'm here for — you're building that cyber knowledge one topic at a time!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation("CyberGuard: My bad that didn't land the way it should have! CyberGuard is always improving — your feedback means a lot!");
            Console.ResetColor();
        }
    }

    static void PrintWithTypingAnimation(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Task.Delay(60).Wait();
        }
        Console.WriteLine();
    }
}