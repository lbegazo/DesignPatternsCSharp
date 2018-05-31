using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPattern
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildOf(string name);
    }

    public class Relationships: IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent,Relationship.Parent,child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildOf(string name)
        {
            return relations
                    .Where(x => x.Item1.Name == "Marco" &&
                        x.Item2 == Relationship.Parent)
                    .Select(x => x.Item3);
        }

        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class Research
    {
        public Research(IRelationshipBrowser relationship)
        {
            //var relations = relationships.Relations;
            //var filter = relations
            //                .Where(x=>x.Item1.Name=="Marco" && 
            //                        x.Item2==Relationship.Parent);

            //foreach (var item in filter)
            //{
            //    WriteLine($"{item.Item1.Name} has a child called {item.Item3.Name}");
            //}

            foreach (var r in relationship.FindAllChildOf("Marco"))
            {
                WriteLine($"Marco has a child called {r.Name}");
            } 
        }
    }
}
