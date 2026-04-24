// =============================================================================
// BotUI.cs
// Handles ALL user-interface: ASCII art, colours, sound, and typewriter effect.
// =============================================================================

using System;
using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Threading;
using System.Speech.Synthesis;

namespace CybersecurityChatbot
{
    internal static class BotUI
    {
        // -------------------- COLOURS --------------------

        public const ConsoleColor BotColour = ConsoleColor.Green;
        public const ConsoleColor UserColour = ConsoleColor.White;
        public const ConsoleColor WarnColour = ConsoleColor.Red;
        public const ConsoleColor BorderColour = ConsoleColor.DarkGreen;

        // -------------------- WELCOME SCREEN --------------------

        public static void ShowWelcomeScreen()
        {
            Console.Clear();
            PrintLogo();
            PlayGreetingSound();
            PrintDivider();

            TypewriterPrint("Welcome to CyberGuard – your cybersecurity assistant.", BotColour);
            TypewriterPrint("I will help you stay safe online.\n", BotColour);

            PrintDivider();
        }

        // -------------------- ASCII LOGO --------------------

        public static void PrintLogo()
        {
            SetColour(BorderColour);
            Console.WriteLine("  ╔══════════════════════════════════════════════════════════════════╗");

            SetColour(BotColour);
            Console.WriteLine(@"
        ██████╗ ███████╗██╗   ██╗ ██████╗ ██████╗  █████╗ ██████╗ 
       ██╔════╝ ██╔════╝██║   ██║██╔════╝ ██╔══██╗██╔══██╗██╔══██╗
       ██║  ███╗█████╗  ██║   ██║██║  ███╗██████╔╝███████║██████╔╝
       ██║   ██║██╔══╝  ██║   ██║██║   ██║██╔══██╗██╔══██║██╔══██╗
       ╚██████╔╝███████╗╚██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║
        ╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝

                 CYBERSECURITY AWARENESS CHATBOT
");

            SetColour(BorderColour);
            Console.WriteLine("  ╚══════════════════════════════════════════════════════════════════╝");

            ResetColour();
            Console.WriteLine();
        }

        // -------------------- VOICE --------------------

        public static void PlayGreetingSound()
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            voice.Speak("Welcome to my cyber security awareness chatt bot");
        }

        // -------------------- TYPEWRITER EFFECT --------------------

        public static void TypewriterPrint(string text, ConsoleColor colour, int delay = 15)
        {
            SetColour(colour);

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            Console.WriteLine();
            ResetColour();
        }

        // -------------------- INPUT --------------------

        public static string GetUserInput()
        {
            SetColour(UserColour);
            Console.Write("\n👤 You » ");
            ResetColour();

            return Console.ReadLine()?.Trim() ?? "";
        }

        // -------------------- BOT LABEL --------------------

        public static void PrintBotLabel()
        {
            SetColour(BorderColour);
            Console.Write("\n🤖 CyberGuard » ");
            ResetColour();
        }

        // -------------------- DIVIDER --------------------

        public static void PrintDivider()
        {
            SetColour(BorderColour);
            Console.WriteLine(new string('─', 70));
            ResetColour();
        }

        // -------------------- FAREWELL --------------------

        public static void ShowFarewell(string name)
        {
            PrintDivider();
            TypewriterPrint($"Goodbye {name}, stay safe online! 🔒", BotColour);
            PrintDivider();
        }

        // -------------------- WARNING --------------------

        public static void ShowWarning(string message)
        {
            SetColour(WarnColour);
            Console.WriteLine($"⚠ {message}");
            ResetColour();
        }

        // -------------------- HELPERS --------------------

        private static void SetColour(ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
        }

        private static void ResetColour()
        {
            Console.ResetColor();
        }
    }
}