using DesignPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.SRP
{
    // just stores a couple of journal entries and ways of
    // working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private int a, b;       

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}  hola");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            /*
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(@"cmd.exe ", @"/c " + filename);
            */
            #region Builder

            //DesignPattern.HtmlBuilder b = new DesignPattern.HtmlBuilder("html");
            //var e = b.AddChild("ul", "");
            //b.AddChild("li", "hola", e);
            //b.AddChild("li", "mundo", e);
            //WriteLine(b.ToString());

            #endregion Builder

            #region Dependency Inversion Principle

            var parent = new Person { Name = "Marco" };
            var child1 = new Person { Name = "Juan" };
            var child2 = new Person { Name = "Antonella" };
            var child3 = new Person { Name = "Bathroom" };

            var relationship = new Relationships();
            relationship.AddParentAndChild(parent, child1);
            relationship.AddParentAndChild(parent, child2);
            relationship.AddParentAndChild(parent, child3);

            var research = new Research(relationship);

            #endregion Dependency Inversion Principle

            ReadKey();
        }
    }
}
